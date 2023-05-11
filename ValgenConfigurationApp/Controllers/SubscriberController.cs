using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ValgenConfigurationApp.Models;
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
        public async Task<SubscriberResponseModel> CreateSubscriber(CreateSubscriberRequestModel requestModel)
        {
            var subscriber = await _subscriberService.NewSubscriber(ToSubscriberRequestModel(requestModel));
            return ConvertIntoSubscribeResponseModel(subscriber);
        }

        /// <summary>
        /// Updating Subscriber.
        /// </summary>
        /// <param name="requestModel">Details which subscriber want to change</param>
        /// <exception cref="Exception">throws when API failed</exception>

        [HttpPut("{id}")]
        public async Task<ActionResult<SubscriberResponseModel>> UpdateSubscriberData(CreateSubscriberRequestModel requestModel, Guid id)
        {
            try
            {
                var subscriber = await _subscriberService.UpdatingSubscriberData(ToSubscriberRequestModel(requestModel), id);
                return Ok(ConvertIntoSubscribeResponseModel(subscriber));
            }
            catch(Exception)
            {
                return NotFound();
            }
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

        private SubscriberResponseModel ConvertIntoSubscribeResponseModel(SubscriberModel model)
        {
            return new SubscriberResponseModel()
            {
                Id = model.Id,
                UserName = model.UserName,
                Email = model.Email,
                Phone = model.Phone,
                SubscriberToken = model.SubscriberToken,
                ConfigJSON = model.ConfigJSON,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                IsActive = model.isActive
            };
        }
    }
}
