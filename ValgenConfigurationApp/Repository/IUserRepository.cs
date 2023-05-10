using ValgenConfigurationApp.Services.Models;

namespace ValgenConfigurationApp.Repository
{
    /// <summary>
    /// IUserRepository Interface.
    /// </summary>
    public interface IUserRepository
    {
        public Task<UserModel> GetUser(string username, string password);
    }
}
