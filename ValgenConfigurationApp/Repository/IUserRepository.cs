using ValgenConfigurationApp.Services.Models;

namespace ValgenConfigurationApp.Repository
{
    /// <summary>
    /// IUserRepository Interface.
    /// </summary>
    public interface IUserRepository
    {
        public Task<UserModel> GetUser(string username, string password);
        public Task<List<SubscriberModel>> GetAllSubscribers();
        public Task CreateNewSubscriber(SubscriberModel subscriber);
        public Task UpdateSubscriber(SubscriberRequestModel subscriber, Guid ID);
    }
}
