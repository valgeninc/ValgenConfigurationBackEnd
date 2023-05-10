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

        // Method for mapping TokenModel into LoginResponseModel.
        private LoginResponseModel ConvertIntoResponseModel(TokenModel token)
        {
            return new LoginResponseModel
            {
                userToken = token.Token
            };
        }
    }
}
