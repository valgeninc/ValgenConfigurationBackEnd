using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using ValgenConfigurationApp.Common;
using ValgenConfigurationApp.Models;
using ValgenConfigurationApp.Repository;
using ValgenConfigurationApp.Repository.Models;
using ValgenConfigurationApp.Services.Models;

namespace ValgenConfigurationApp.Services
{
    /// <summary>
    /// SubscriberService class.
    /// </summary>

    public class SubscriberService : ISubscriberService
    {
        private readonly IConfiguration _configuration;
        private readonly ISubscriberRepository _subscriberRepository;

        public SubscriberService(IConfiguration configuration, ISubscriberRepository subscriberRepository)
        {
            _configuration = configuration;
            _subscriberRepository = subscriberRepository;
        }

        // Method for getting Subscribers list.
        public async Task<List<SubscriberModel>> GetSubscribers()
        {
            List<SubscriberModel> subscribers = await _subscriberRepository.GetAllSubscribers();
            return subscribers;
        }

        // Method for creating subscriber.
        public async Task NewSubscriber(SubscriberRequestModel model)
        {
            await _subscriberRepository.CreateSubscriber(model);
        }

        // Method for creating subscription.
        public async Task<ApiResponseModel> NewSubscription(SubscriptionRequestModel subscription)
        {
            try
            {
                Subscribers subscribers = await _subscriberRepository.CheckSubscriber(subscription.SubscriberId);
                if (subscribers is not null)
                {
                    subscription.SubscriptionId = Guid.NewGuid();
                    subscription = GenerateSubscriberToken(subscribers, subscription);
                }
                await _subscriberRepository.CreateSubscription(subscription);
                return new ApiResponseModel { Status = HttpStatusCode.OK.ToString(), Result = "Saved Successfully!!" };
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Method for updating subscription.
        public async Task UpdateSubscription(SubscriptionRequestModel subscription)
        {
            Subscriptions subs = await GetSubscription(subscription.SubscriptionId);
            await _subscriberRepository.UpdateSubscription(subs, subscription);
        }

        // Method for updating subscriber.
        public async Task<SubscriberModel> UpdatingSubscriberData(SubscriberRequestModel model, Guid id)
        {
            try
            {
                return await _subscriberRepository.UpdateSubscriber(model, id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ColumnList> GetColumnList()
        {
            try
            {
                return await _subscriberRepository.GetColumnList(_configuration.GetConnectionString("ValgenDB"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<SubscriptionModel>> GetSubscriptions(Guid subscriberId)
        {
            List<Subscriptions> subscriptions = await _subscriberRepository.GetAllSubscriptions(subscriberId);
            List<SubscriptionModel> models = new List<SubscriptionModel>();

            if (subscriptions.Count > 0)
            {
                foreach (var s in subscriptions)
                {
                    SubscriptionModel req = new SubscriptionModel();
                    req.SubscriberToken = EncryptionDecryptionUtility.DecryptString(s.Token, _configuration["Encryption:Key"]);
                    req.SubscriberId = subscriberId;
                    req.SubscriptionId = s.SubscriptionId;
                    req.StartDate = s.StartDate;
                    req.EndDate = s.EndDate;
                    req.MaxRequests = s.MaxRequests;
                    req.TimeWindow = s.TimeWindow;
                    req.isActive = s.isActive;
                    req.SubscriptionServicesModel = new List<SubscriptionServicesModel>();
                    foreach (var services in s.SubscriptionServices)
                    {
                        SubscriptionServicesModel serviceModel = new SubscriptionServicesModel();
                        serviceModel.SubscriptionId = services.SubscriptionId;
                        serviceModel.ServiceId = services.ServiceId;
                        SubscriptionServicesDeserialized json = JsonConvert.DeserializeObject<SubscriptionServicesDeserialized>(services.ConfigJson);
                        serviceModel.Columns = json.Columns;
                        serviceModel.CompanyRecords = json.CompanyRecords;
                        serviceModel.LocationRecords = json.LocationRecords;
                        serviceModel.EndPointDesc = await _subscriberRepository.GetEndPointDesc(services.EndPointId);
                        req.SubscriptionServicesModel.Add(serviceModel);
                    }
                    models.Add(req);
                }
            }
            return models;
        }

        // Method for activating/deactivating subscription.
        public async Task RenewSubscription(RenewSubscriptionModel model)
        {
            await _subscriberRepository.RenewSubscription(model);
        }

        // Method for refresh token subscription.
        public async Task<string> RefreshToken(Guid subscriptionId)
        {
            var subs = await GetSubscription(subscriptionId);
            SubscriptionRequestModel subsRequestModel = new SubscriptionRequestModel();
            subsRequestModel.SubscriptionId = subs.SubscriptionId;
            subsRequestModel = GenerateSubscriberToken(subs.Subscriber, subsRequestModel);
            await _subscriberRepository.UpdateRefreshToken(subsRequestModel);

            return EncryptionDecryptionUtility.DecryptString(subsRequestModel.SubscriberToken, _configuration["Encryption:Key"]); 
        }

        private async Task<Subscriptions> GetSubscription(Guid subscriptionId)
        {
            return await _subscriberRepository.CheckSubscription(subscriptionId);
        }

        // Method for generating subscriber token.
        private SubscriptionRequestModel GenerateSubscriberToken(Subscribers model, SubscriptionRequestModel subscription)
        {
            subscription.RefreshTokenId = Guid.NewGuid();
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? ""));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
                    {
                         new Claim(ClaimTypes.NameIdentifier, model.Name),
                         new Claim("Id",subscription.SubscriptionId.ToString()) ,
                         new Claim("RefreshTokenId",subscription.RefreshTokenId.ToString())
                    };

            var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    signingCredentials: credentials);
            subscription.SubscriberToken = EncryptionDecryptionUtility.EncryptString(new JwtSecurityTokenHandler().WriteToken(token), _configuration["Encryption:Key"]);
            return subscription;
        }
    }
}
