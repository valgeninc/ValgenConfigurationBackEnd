using ValgenConfigurationApp.Services.Models;

namespace ValgenConfigurationApp.Services
{
    /// <summary>
    /// ILoginAuthentication Interface.
    /// </summary>
    
    public interface IUserService
    {
        public Task<TokenModel> UserLogin(UserModel user);
    }
}
