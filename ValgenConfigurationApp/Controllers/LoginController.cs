﻿using Microsoft.AspNetCore.Mvc;
using System.Net;
using ValgenConfigurationApp.Models;
using ValgenConfigurationApp.Services;
using ValgenConfigurationApp.Services.Models;

namespace ValgenConfigurationApp.Controllers
{
    /// <summary>
    /// In LoginController we are logging in api by checking 
    /// user credentials and validating jwt Token.
    /// </summary>

    [Route("api/login")]
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
        public async Task<ApiResponseModel> Login(LoginRequestModel loginRequest)
        {
            if (loginRequest == null || loginRequest.userName == null || loginRequest.userPassword == null)
            {
                throw (new Exception("Invalid Request"));
            }

            try
            {
                var loginData = await _userService.UserLogin(loginRequest.userName, loginRequest.userPassword);
                LoginResponseModel loginResponse = ConvertIntoResponseModel(loginData);
                return new ApiResponseModel { Status = HttpStatusCode.OK.ToString(), Result = loginResponse };
            }
            catch (Exception ex)
            {
                throw;
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
