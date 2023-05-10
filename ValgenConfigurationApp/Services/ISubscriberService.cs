using ValgenConfigurationApp.Services.Models;

namespace ValgenConfigurationApp.Services
{
    public interface ISubscriberService
    {
        public Task<List<SubscriberModel>> GetSubscribers();
        public Task NewSubscriber(SubscriberRequestModel subscriber);
        public Task UpdatingSubscriberData(SubscriberRequestModel subscriber, Guid ID);
    }
}
