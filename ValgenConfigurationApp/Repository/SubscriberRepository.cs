using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using System.Data;
using ValgenConfigurationApp.Common;
using ValgenConfigurationApp.Repository.Models;
using ValgenConfigurationApp.Services.Models;

namespace ValgenConfigurationApp.Repository
{
    /// <summary>
    /// SubscriberRepository class.
    /// </summary>

    public class SubscriberRepository : ISubscriberRepository
    {
        private readonly DatabaseContext _databaseContext;

        public SubscriberRepository(DatabaseContext databaseContext)
        {
            if (databaseContext == null)
                throw new ArgumentNullException(nameof(databaseContext));

            _databaseContext = databaseContext;
        }

        // Method for Getting the list of Subscribers.
        public async Task<List<SubscriberModel>> GetAllSubscribers()
        {
            List<Subscribers> subscribers = new List<Subscribers>();
            try
            {
                subscribers = await _databaseContext.Subscribers.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return ToSubscriberModel(subscribers);
        }

        // Method for creating new Subscriber.
        public async Task CreateSubscriber(SubscriberRequestModel model)
        {
            try
            {
                _databaseContext.Subscribers.Add(ToSubscribers(model));
                await _databaseContext.SaveChangesAsync();
                await ApiLogging.InsertLog(SerializeDeserialize.SerializeObject(model), Enums.MessageType.Subscribers.ToString(), model.Id, _databaseContext);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Method for updating subscriber details.
        public async Task<SubscriberModel> UpdateSubscriber(SubscriberRequestModel model, Guid id)
        {
            Subscribers subscriber = await CheckSubscriber(id);
            if (subscriber == null)
            {
                throw new ArgumentException("Subscriber not found."); ;
            }

            subscriber.Name = model.Name;
            subscriber.Email = model.Email;
            subscriber.Phone = model.Phone;
            await _databaseContext.SaveChangesAsync();
            await ApiLogging.InsertLog(SerializeDeserialize.SerializeObject(model), Enums.MessageType.Subscribers.ToString(), id, _databaseContext);
            return ConvertIntoSubscriberModel(subscriber);
        }

        // Method for creating new Subscription.
        public async Task CreateSubscription(SubscriptionRequestModel model)
        {
            using (IDbContextTransaction transaction = _databaseContext.Database.BeginTransaction())
            {
                try
                {
                    string messageType = Enums.MessageType.Subscriptions.ToString();
                    await _databaseContext.Subscriptions.AddAsync(new Subscriptions()
                    {
                        SubscriberId = model.SubscriberId,
                        SubscriptionId = model.SubscriptionId,
                        EndDate = model.EndDate,
                        StartDate = model.StartDate,
                        Token = model.SubscriberToken,
                        MaxRequests = model.MaxRequests,
                        TimeWindow = model.TimeWindow,
                        isActive = model.IsActive,
                        RefreshTokenId = model.RefreshTokenId
                    });
                    List<SubscriptionServices> subscriptionServices = new List<SubscriptionServices>();
                    if (model.SubscriptionServicesMainModel.Count > 0)
                    {
                        foreach (var m in model.SubscriptionServicesMainModel)
                        {
                            var endPoints = await GetEndPoints(m.EndPointDesc);
                            subscriptionServices.Add(new SubscriptionServices { SubscriptionId = model.SubscriptionId, ConfigJson = m.ConfigJson, EndPointId = endPoints.EndPointId });
                            if (m.AdditionalCompanyRecords != 0 || m.AdditionalLocationRecords != 0)
                            {
                                messageType = Enums.MessageType.AdditionalPullRecords.ToString();
                            }
                        }
                        await _databaseContext.SubscriptionServices.AddRangeAsync(subscriptionServices);
                    }
                    await _databaseContext.SaveChangesAsync();

                    string s = JsonConvert.SerializeObject(model);
                    await ApiLogging.InsertLog(SerializeDeserialize.SerializeObject(model), messageType, model.SubscriptionId, _databaseContext);
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        // Method for creating new Subscription.
        public async Task UpdateSubscription(Subscriptions model, SubscriptionRequestModel subscriptionRequest)
        {
            using (IDbContextTransaction transaction = _databaseContext.Database.BeginTransaction())
            {
                try
                {
                    /* Edit in Subscriptions */
                    model.EndDate = subscriptionRequest.EndDate;
                    model.StartDate = subscriptionRequest.StartDate;
                    model.MaxRequests = subscriptionRequest.MaxRequests;
                    model.TimeWindow = subscriptionRequest.TimeWindow;
                    model.isActive = subscriptionRequest.IsActive;
                    List<SubscriptionServices> subs = model.SubscriptionServices.ToList();
                    foreach (var m in subscriptionRequest.SubscriptionServicesMainModel)
                    {
                        APIEndPoints e = await GetEndPoints(m.EndPointDesc);
                        SubscriptionServices s = subs.First(a => a.ServiceId == m.ServiceId);
                        s.ConfigJson = m.ConfigJson;
                        s.EndPointId = e.EndPointId;
                    }
                    _databaseContext.SubscriptionServices.UpdateRange(subs);
                    await _databaseContext.SaveChangesAsync();
                    await ApiLogging.InsertLog(SerializeDeserialize.SerializeObject(model), Enums.MessageType.Subscriptions.ToString(), model.SubscriptionId, _databaseContext);
                    transaction.Commit();
                }
                catch (Exception) { transaction.Rollback(); throw; }
            }
        }

        // Method for Getting the list of Subscription.
        public async Task<List<Subscriptions>> GetAllSubscriptions(Guid subscriberId)
        {
            List<Subscriptions> subscriptions = new List<Subscriptions>();
            try
            {
                subscriptions = await _databaseContext.Subscriptions.Where(a => a.SubscriberId == subscriberId).Include(a => a.SubscriptionServices).ToListAsync();
                return subscriptions;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Method for getting Columns.
        public async Task<ColumnList> GetColumnList(string conStr)
        {
            using var connection = new SqlConnection(conStr);
            var query = "select col.Column_Name,api.EndPointDesc from columnsmaster col,APIEndPoints api" +
                        " where col.APIEndPointId = api.EndPointId" +
                        " order by col.Column_Name asc ";
            using var command = new SqlCommand(query, connection);
            if (connection.State == ConnectionState.Closed)
            {
                await connection.OpenAsync();
            }
            var dataReader = await command.ExecuteReaderAsync();
            ColumnList col = new ColumnList();
            col.AnonymizedColumnList = new List<string>();
            col.IdentifiedColumnList = new List<string>();
            while (await dataReader.ReadAsync())
            {
                if (dataReader["EndPointDesc"].ToString().ToUpper() == "ANONYMIZEDDETAIL")
                    col.AnonymizedColumnList.Add(dataReader["Column_name"].ToString());
                else
                    col.IdentifiedColumnList.Add(dataReader["Column_name"].ToString());
            }
            if (connection.State != ConnectionState.Closed)
            {
                await connection.CloseAsync();
            }
            return col;
        }

        //Method fpr renew subscription.
        public async Task RenewSubscription(RenewSubscriptionModel model)
        {
            try
            {
                await _databaseContext.Subscriptions.Where(a => a.SubscriptionId == model.SubscriptionId).ExecuteUpdateAsync(a => a.SetProperty(x => x.isActive, x => model.IsActive));
                await ApiLogging.InsertLog(SerializeDeserialize.SerializeObject(model), Enums.MessageType.RenewSubscription.ToString(), model.SubscriptionId, _databaseContext);
            }
            catch (Exception)
            {
                throw;
            }
        }


        // Method for getting Subscriber Details.
        public async Task<Subscribers> CheckSubscriber(Guid subscriberId)
        {
            try
            {
                return await _databaseContext.Subscribers.Include(a => a.Subscriptions).FirstAsync(a => a.Id == subscriberId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Method for checking Subscriptions.
        public async Task<Subscriptions> CheckSubscription(Guid subscriptionId)
        {
            try
            {
                return await _databaseContext.Subscriptions.Include(a => a.SubscriptionServices).Include(a => a.Subscriber).FirstAsync(u => u.SubscriptionId == subscriptionId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Method for getting Subscription Services.
        public async Task<List<SubscriptionServices>> GetSubscriptionServices(Guid subscriptionId)
        {
            try
            {
                return await _databaseContext.SubscriptionServices.Where(u => u.SubscriptionId == subscriptionId).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ServicesTracking>> GetServicesTracking(Guid subscriptionId)
        {
            try
            {
                List<ServicesTracking> servicesTrack = await _databaseContext.ServicesTrackings.Where(u => u.SubscriptionId == subscriptionId).ToListAsync();
                return servicesTrack;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<ServicesTracking>> GetServicesTracking(Guid subscriptionId, Guid endPointId)
        {
            try
            {
                List<ServicesTracking> servicesTrack = await _databaseContext.ServicesTrackings.Where(u => u.SubscriptionId == subscriptionId && u.EndPointId == endPointId).ToListAsync();
                return servicesTrack;
            }
            catch (Exception)
            {
                throw;
            }
        }



        // Method for getting EndPointId.
        public async Task<APIEndPoints> GetEndPoints(string? endPointDesc)
        {
            try
            {
                return await _databaseContext.APIEndPoints.FirstAsync(a => a.EndPointDesc == endPointDesc);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Method for getting EndPointId.
        public async Task<string> GetEndPointDesc(Guid endPointId)
        {
            try
            {
                var endPoint = await _databaseContext.APIEndPoints.FirstAsync(a => a.EndPointId == endPointId);
                return endPoint.EndPointDesc;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // Method for updating refresh token.
        public async Task UpdateRefreshToken(SubscriptionRequestModel model)
        {
            try
            {
                await _databaseContext.Subscriptions.Where(a => a.SubscriptionId == model.SubscriptionId).ExecuteUpdateAsync(a => a
                .SetProperty(x => x.RefreshTokenId, x => model.RefreshTokenId)
                .SetProperty(x => x.Token, x => model.SubscriberToken));
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Method for Getting the name of Subscriber.
        public async Task<string> GetSubscriberName(Guid subscriberId)
        {
            try
            {
                var subs = await _databaseContext.Subscribers.FirstAsync(a => a.Id == subscriberId);
                return subs.Name;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Method for mapping List<Subscribers> into List<SubscriberModel>.
        private List<SubscriberModel> ToSubscriberModel(List<Subscribers> subscriberList)
        {
            var subs = subscriberList.Select(s => new SubscriberModel
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Phone = s.Phone,
            }).ToList();
            return subs;
        }

        private Subscribers ToSubscribers(SubscriberRequestModel model)
        {
            return new Subscribers
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone
            };
        }

        private SubscriberModel ConvertIntoSubscriberModel(Subscribers model)
        {
            return new SubscriberModel
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
            };
        }
    }
}
