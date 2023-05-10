using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ValgenConfigurationApp.Models;
using ValgenConfigurationApp.Services;
using ValgenConfigurationApp.Services.Models;

namespace ValgenConfigurationApp.Controllers
{
    [Authorize]
    [Route("api/[action]")]
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
        public async Task<List<SubscriberResponseModel>> GetSubscriberData()
        {
            List<SubscriberModel> subscriberData = await _subscriberService.GetSubscribers();
            return ToSubscriberResponseModel(subscriberData);
        }

        /// <summary>
        /// Creating Subscriber.
        /// </summary>
        /// <param name="requestModel">Details of Subscriber</param>
        /// <exception cref="Exception">throws when API failed</exception>

        [HttpPost]
        public async Task CreateSubscriber(CreateSubscriberRequestModel requestModel)
        {
            await _subscriberService.NewSubscriber(ToSubscriberRequestModel(requestModel));

        }

        /// <summary>
        /// Updating Subscriber.
        /// </summary>
        /// <param name="requestModel">Details which subscriber want to change</param>
        /// <exception cref="Exception">throws when API failed</exception>

        [HttpPut("{ID}")]
        public async Task UpdateSubscriberData(CreateSubscriberRequestModel requestModel, Guid ID)
        {
            await _subscriberService.UpdatingSubscriberData(ToSubscriberRequestModel(requestModel), ID);
        }

        // Method for mapping List<SubscriberModel> into List<SubscriberResponseModel>.
        private List<SubscriberResponseModel> ToSubscriberResponseModel(List<SubscriberModel> modelList)
        {
            var subscriber = modelList.Select(s => new SubscriberResponseModel
            {
                Id = s.Id,
                UserName = s.UserName,
                Email = s.Email,
                Phone = s.Phone,
                SubscriberToken = s.SubscriberToken,
                StartDate = s.StartDate,
                EndDate = s.EndDate,
                ConfigJSON = s.ConfigJSON,
                IsActive = s.isActive
            }).ToList();

            return subscriber;
        }

        // Method for Converting CreateSubscriberRequestModel into SubscriberRequestModel.
        private SubscriberRequestModel ToSubscriberRequestModel(CreateSubscriberRequestModel model)
        {
            return new SubscriberRequestModel()
            {
                UserName = model.SubscriberUserName,
                Email = model.SubscriberEmail,
                Phone = model.SubscriberPhone,
                ConfigJSON = model.ConfigJSON,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                isActive = model.isActive
            };
        }
    }
}
