using ValgenConfigurationApp.Services.Models;

namespace ValgenConfigurationApp.Services
{
    public interface ISubscriberService
    {
        /// <summary>
        /// ISubscriberService class.
        /// </summary>
        /// <returns></returns>
        public Task<List<SubscriberModel>> GetSubscribers();
        public Task<SubscriberModel> NewSubscriber(SubscriberRequestModel subscriber);
        public Task<SubscriberModel> UpdatingSubscriberData(SubscriberRequestModel subscriber, Guid id);
    }
}
