using ValgenConfigurationApp.Models;
using ValgenConfigurationApp.Repository.Models;
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
        public Task NewSubscriber(SubscriberRequestModel subscriber);
        public Task<SubscriberModel> UpdatingSubscriberData(SubscriberRequestModel subscriber, Guid id);
        public Task<ColumnList> GetColumnList();
        public Task<ApiResponseModel> NewSubscription(SubscriptionRequestModel model);
        public Task<List<SubscriptionModel>> GetSubscriptions(Guid subscriberId);
        public Task UpdateSubscription(SubscriptionRequestModel model);
        public Task RenewSubscription(RenewSubscriptionModel model);
        public Task<string> RefreshToken(Guid subscriptionId);
        public Task<string> GetSubscriberName(Guid subscriberId);
        public Task<TrackingDetailList> GetServicesTracking(Guid subscriptionId);
    }
}
