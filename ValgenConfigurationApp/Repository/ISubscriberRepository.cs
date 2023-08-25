using ValgenConfigurationApp.Repository.Models;
using ValgenConfigurationApp.Services.Models;

namespace ValgenConfigurationApp.Repository
{
    /// <summary>
    /// ISubscriberRepository class.
    /// </summary>
    public interface ISubscriberRepository
    {
        public Task<List<SubscriberModel>> GetAllSubscribers();
        public Task CreateSubscriber(SubscriberRequestModel subscriber);
        public Task<SubscriberModel> UpdateSubscriber(SubscriberRequestModel subscriber, Guid id);
        public Task<ColumnList> GetColumnList(string conStr);
        public Task<Subscribers> CheckSubscriber(Guid subscriberId);
        public Task CreateSubscription(SubscriptionRequestModel model);
        public Task<Subscriptions> CheckSubscription(Guid subscriptionId);
        public Task<List<Subscriptions>> GetAllSubscriptions(Guid subscriberId);
        public Task UpdateSubscription(Subscriptions model, SubscriptionRequestModel subscriptionRequest);
        public Task<APIEndPoints> GetEndPoints(string? endPointDesc);
        public Task<string> GetEndPointDesc(Guid endPointId);
        public Task RenewSubscription(RenewSubscriptionModel model);
        public Task UpdateRefreshToken(SubscriptionRequestModel model);
    }
}
