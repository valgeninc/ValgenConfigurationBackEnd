using ValgenConfigurationApp.Services.Models;

namespace ValgenConfigurationApp.Services
{
    /// <summary>
    /// IUserService Interface.
    /// </summary>
    
    public interface IUserService
    {
        public Task<TokenModel> UserLogin(string userName, string userPassword);
    }
}
