using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using ValgenConfigurationApp.Models;
using ValgenConfigurationApp.Repository.Models;
using ValgenConfigurationApp.Services;
using ValgenConfigurationApp.Services.Models;

namespace ValgenConfigurationApp.Controllers
{
    /// <summary>
    /// SubscriberController class.
    /// </summary>

    [Authorize]
    [Route("api/subscribers")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        public readonly ISubscriberService _subscriberService;
        public SubscriberController(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }

        /// <summary>
        /// Getting Subscriber Data
        /// </summary>
        /// <returns>Subscribers response</returns>
        /// <exception cref="Exception">throws when API failed</exception>

        [HttpGet]
        public async Task<ApiResponseModel> GetSubscribers()
        {
            try
            {
                List<SubscriberModel> subscriberData = await _subscriberService.GetSubscribers();
                return new ApiResponseModel(HttpStatusCode.OK, subscriberData);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Creating Subscriber.
        /// </summary>
        /// <param name="requestModel">Details of Subscriber</param>
        /// <exception cref="Exception">throws when API failed</exception>

        [HttpPost]
        public async Task<ApiResponseModel> CreateSubscriber(CreateSubscriberRequestModel requestModel)
        {
            try
            {
                await _subscriberService.NewSubscriber(ToSubscriberRequestModel(requestModel));
                return new ApiResponseModel { Status = HttpStatusCode.OK.ToString(), Result = "Record Saved Successfully!!" };
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Updating Subscriber.
        /// </summary>
        /// <param name="requestModel">Details which subscriber want to change</param>
        /// <exception cref="Exception">throws when API failed</exception>

        [HttpPut("{id}")]
        public async Task<ApiResponseModel> UpdateSubscriber(CreateSubscriberRequestModel requestModel, Guid id)
        {
            try
            {
                var subscriber = await _subscriberService.UpdatingSubscriberData(ToSubscriberRequestModel(requestModel), id);
                return new ApiResponseModel(HttpStatusCode.OK, "Record Updated Successfully!!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Columns List.
        /// </summary>
        [HttpGet]
        [Route("GetColumnList")]
        public async Task<ApiResponseModel> GetColumnsList()
        {
            try
            {
                var response = await _subscriberService.GetColumnList();
                return new ApiResponseModel(HttpStatusCode.OK, response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Create Subscription.
        /// </summary>
        [HttpPost]
        [Route("CreateSubscription")]
        public async Task<ApiResponseModel> CreateSubscription(CreateSubscriptionRequestModel requestModel)
        {
            try
            {
                return await _subscriberService.NewSubscription(ToSubscriptionRequestModel(requestModel));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Update Subscription.
        /// </summary>
        [HttpPut]
        [Route("UpdateSubscription")]
        public async Task<ApiResponseModel> UpdateSubscription(CreateSubscriptionRequestModel requestModel)
        {
            try
            {
                await _subscriberService.UpdateSubscription(ToSubscriptionRequestModel(requestModel));
                return new ApiResponseModel(HttpStatusCode.OK, "Record Updated Successfully!!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Renew Subscription.
        /// </summary>
        [HttpPut]
        [Route("RenewSubscription")]
        public async Task<ApiResponseModel> RenewSubscription(RenewSubscriptionRequestModel requestModel)
        {
            try
            {
                await _subscriberService.RenewSubscription(new RenewSubscriptionModel() { SubscriptionId = requestModel.SubscriptionId, IsActive = requestModel.IsActive });
                return new ApiResponseModel { Status = HttpStatusCode.OK.ToString(), Result = "Record Updated Successfully!!" };
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Subscription.
        /// </summary>
        [HttpGet]
        [Route("GetSubscription")]
        public async Task<ApiResponseModel> GetSubscription(Guid SubscriberId)
        {
            try
            {
                List<SubscriptionModel> subscription = await _subscriberService.GetSubscriptions(SubscriberId);
                return new ApiResponseModel { Status = HttpStatusCode.OK.ToString(), Result = subscription };
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Refresh Token.
        /// </summary>
        [HttpPut]
        [Route("RefreshToken")]
        public async Task<ApiResponseModel> RefreshToken(Guid SubscriptionId)
        {
            try
            {
                string token = await _subscriberService.RefreshToken(SubscriptionId);
                return new ApiResponseModel { Status = HttpStatusCode.OK.ToString(), Result = token };
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Method for mapping List<SubscriberModel> into List<SubscriberResponseModel>.
        private List<SubscriberResponseModel> ToSubscriberResponseModel(List<SubscriberModel> modelList)
        {
            var subscriber = modelList.Select(s => new SubscriberResponseModel
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Phone = s.Phone,

            }).ToList();

            return subscriber;
        }

        // Method for Converting CreateSubscriberRequestModel into SubscriberRequestModel.
        private SubscriberRequestModel ToSubscriberRequestModel(CreateSubscriberRequestModel model)
        {
            return new SubscriberRequestModel()
            {
                Name = model.Name,
                Email = model.Email,
                Phone = model.Phone,
            };
        }

        private SubscriptionRequestModel ToSubscriptionRequestModel(CreateSubscriptionRequestModel model)
        {

            SubscriptionRequestModel subscriptions = new SubscriptionRequestModel();
            List<SubscriptionServiceModel> subs = new List<SubscriptionServiceModel>();
            List<SubscriptionServicesMainModel> list = new List<SubscriptionServicesMainModel>();
            foreach (var s in model.CreateSubscriptionServicesModel)
            {
                SubscriptionServiceModel services = new SubscriptionServiceModel();
                services.CompanyRecords = s.CompanyRecords;
                services.LocationRecords = s.LocationRecords;
                services.Columns = s.Columns;
                subs.Add(services);
                var convert = JsonConvert.SerializeObject(services);
                list.Add(new SubscriptionServicesMainModel() { ServiceId = s.ServiceId, EndPointDesc = s.EndPointDesc, ConfigJson = convert });
            }

            return new SubscriptionRequestModel()
            {
                SubscriberId = model.SubscriberId,
                SubscriptionId = model.SubscriptionId,
                MaxRequests = model.MaxRequests,
                TimeWindow = model.TimeWindow,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                IsActive = model.IsActive,
                SubscriptionServiceModel = subs,
                SubscriptionServicesMainModel = list
            };
        }
    }
}
