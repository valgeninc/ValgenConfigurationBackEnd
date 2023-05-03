using Microsoft.AspNetCore.Mvc;
using ValgenConfigurationApp.Models;
using ValgenConfigurationApp.Services;
using ValgenConfigurationApp.Services.Models;

namespace ValgenConfigurationApp.Controllers
{
    /// <summary>
    /// LoginController.
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        // UserLogin Method checking if user is present in database and genrating Jwt token.
        [HttpPost]
        public async Task<ActionResult<LoginResponseModel>> Login(LoginRequestModel users)
        {
            UserModel user = ConvertIntoServiceModel(users);
            var loginData = await _userService.UserLogin(user);
            LoginResponseModel rsModel = ConvertIntoResponseModel(loginData);
            if(loginData == null)
            {
                return BadRequest();
            }
            return Ok(rsModel);
        }

        // Method for mapping LoginRequestModel into UserModel.
        private UserModel ConvertIntoServiceModel(LoginRequestModel model)
        {
            return new UserModel
            {
                Id = model.Id,
                userName = model.userName,
                userPassword = model.userPassword,
            };
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
