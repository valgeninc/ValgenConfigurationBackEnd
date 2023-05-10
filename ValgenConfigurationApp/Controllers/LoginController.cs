using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ValgenConfigurationApp.Models;
using ValgenConfigurationApp.Services;
using ValgenConfigurationApp.Services.Models;

namespace ValgenConfigurationApp.Controllers
{
    /// <summary>
    /// In LoginController we are logging in api by checking 
    /// user credentials and validating jwt Token.
    /// </summary>

    [Route("api/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Authenticate user and return JWT token as response
        /// </summary>
        /// <param name="loginRequest">Login detail of user</param>
        /// <returns>Login response</returns>
        /// <exception cref="Exception">throws when API failed</exception>

        [HttpPost]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel loginRequest)
        {
            if (loginRequest == null || loginRequest.userName == null || loginRequest.userPassword == null)
            {
                return BadRequest();
            }

            try
            {
                var loginData = await _userService.UserLogin(loginRequest.userName, loginRequest.userPassword);
                LoginResponseModel loginResponse = ConvertIntoResponseModel(loginData);
                return Ok(loginResponse);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        /// <summary>
        /// Getting Subscriber Data
        /// </summary>
        /// <returns>Subscribers response</returns>
        /// <exception cref="Exception">throws when API failed</exception>

        [Authorize]
        [HttpGet]
        public async Task<List<SubscriberResponseModel>> GetSubscriberData()
        {
            List<SubscriberModel> subscriberData = await _userService.GetSubscribers();
            return ToSubscriberResponseModel(subscriberData);
        }

        /// <summary>
        /// Creating Subscriber.
        /// </summary>
        /// <param name="requestModel">Details of Subscriber</param>
        /// <exception cref="Exception">throws when API failed</exception>

        [Authorize]
        [HttpPost]
        public async Task CreateSubscriber(CreateSubscriberRequestModel requestModel)
        {
            await _userService.NewSubscriber(ToSubscriberRequestModel(requestModel));

        }

        /// <summary>
        /// Updating Subscriber.
        /// </summary>
        /// <param name="requestModel">Details which subscriber want to change</param>
        /// <exception cref="Exception">throws when API failed</exception>
        
        [Authorize]
        [HttpPut("{ID}")]
        public async Task UpdateSubscriberData(CreateSubscriberRequestModel requestModel, Guid ID)
        {
            await _userService.UpdatingSubscriberData(ToSubscriberRequestModel(requestModel), ID);
        }

        // Method for mapping TokenModel into LoginResponseModel.
        private LoginResponseModel ConvertIntoResponseModel(TokenModel token)
        {
            return new LoginResponseModel
            {
                userToken = token.Token
            };
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
