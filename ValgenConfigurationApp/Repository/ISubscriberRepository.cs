using ValgenConfigurationApp.Services.Models;

namespace ValgenConfigurationApp.Repository
{
    public interface ISubscriberRepository
    {
        public Task<List<SubscriberModel>> GetAllSubscribers();
        public Task CreateNewSubscriber(SubscriberModel subscriber);
        public Task UpdateSubscriber(SubscriberRequestModel subscriber, Guid ID);
    }
}
