using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ValgenConfigurationApp.Repository;
using ValgenConfigurationApp.Services.Models;

namespace ValgenConfigurationApp.Services
{
    /// <summary>
    ///  UserService Class Generating Token.
    /// </summary>
    
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public UserService(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        // Method for authenticating user login credentials.
        public async Task<TokenModel> UserLogin(string userName, string userPassword)
        {
            var User = await _userRepository.GetUser(userName, userPassword);

            if (User == null)
            {
                throw new ArgumentException(userName + " not found");
            }

            TokenModel token = new TokenModel();
            token.Token = GenerateToken(User.Id, userName);
            return token;
        }

        // Method for getting Subscribers list.
        public async Task<List<SubscriberModel>> GetSubscribers()
        {
            List<SubscriberModel> subscribers = await _userRepository.GetAllSubscribers();
            return subscribers;
        }

        // Method for creating subscriber.
        public async Task NewSubscriber(SubscriberRequestModel model)
        {
            SubscriberModel subscriber = GenerateSubscriberToken(model);
            await _userRepository.CreateNewSubscriber(subscriber);
        }

        // Method for updating subscriber.
        public async Task UpdatingSubscriberData(SubscriberRequestModel model, Guid ID)
        {
            await _userRepository.UpdateSubscriber(model, ID);
        }

        // Method for generating Token.
        private string GenerateToken(int id, string userName)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? ""));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
                    {
                         new Claim("Id", id.ToString()),
                         new Claim(ClaimTypes.NameIdentifier, userName)
                    };

            var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // Method for generating subscriber token.
        private SubscriberModel GenerateSubscriberToken(SubscriberRequestModel model)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? ""));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
                    {
                         new Claim(ClaimTypes.NameIdentifier, model.UserName),
                         new Claim(ClaimTypes.NameIdentifier, model.Email ?? ""),
                         new Claim(ClaimTypes.NameIdentifier, model.Phone ?? "")
                    };

            var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: credentials);

            return new SubscriberModel()
            {
                UserName = model.UserName,
                Email = model.Email,
                Phone = model.Phone,
                SubscriberToken = new JwtSecurityTokenHandler().WriteToken(token),
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                ConfigJSON = model.ConfigJSON,
                isActive = model.isActive
            };
        }
    }
}
