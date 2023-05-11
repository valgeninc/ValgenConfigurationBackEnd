using ValgenConfigurationApp.Services.Models;

namespace ValgenConfigurationApp.Repository
{
    /// <summary>
    /// ISubscriberRepository class.
    /// </summary>
    public interface ISubscriberRepository
    {
        public Task<List<SubscriberModel>> GetAllSubscribers();
        public Task<SubscriberModel> CreateNewSubscriber(SubscriberModel subscriber);
        public Task<SubscriberModel> UpdateSubscriber(SubscriberRequestModel subscriber, Guid id);
    }
}
