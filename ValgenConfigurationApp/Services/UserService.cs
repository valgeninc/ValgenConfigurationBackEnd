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

        // Method for generating Token.
        private string GenerateToken(int id, string userName)
        {
            const int TOKEN_EXPIRE_TIME = 10;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtAdmin:Key"] ?? ""));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
                    {
                         new Claim("Id", id.ToString()),
                         new Claim(ClaimTypes.NameIdentifier, userName)
                    };

            var token = new JwtSecurityToken(
                    _configuration["JwtAdmin:Issuer"],
                    _configuration["JwtAdmin:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(TOKEN_EXPIRE_TIME),
                    signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
