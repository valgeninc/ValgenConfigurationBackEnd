using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ValgenConfigurationApp.Repository;
using ValgenConfigurationApp.Services.Models;

namespace ValgenConfigurationApp.Services
{
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
            SubscriberModel subscriber = GenerateSubscriberToken(model);
            await _subscriberRepository.CreateNewSubscriber(subscriber);
        }

        // Method for updating subscriber.
        public async Task UpdatingSubscriberData(SubscriberRequestModel model, Guid ID)
        {
            await _subscriberRepository.UpdateSubscriber(model, ID);
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
