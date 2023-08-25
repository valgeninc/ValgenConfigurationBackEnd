using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ValgenConfigurationApp.Repository.Models
{
    /// <summary>
    /// Subscription class.
    /// </summary>

    public class Subscriptions
    {
        [Key]
        public Guid SubscriptionId { get; set; }
        public Guid SubscriberId { get; set; }
        [JsonIgnore]
        public virtual Subscribers Subscriber { get; set; }
        public string? Token { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MaxRequests { get; set; }
        public int TimeWindow { get; set; }
        public bool? isActive { get; set; }
        public Guid? RefreshTokenId { get; set; }
        public ICollection<SubscriptionServices> SubscriptionServices { get; set; }
    }

    /// <summary>
    /// SubscriptionServices class.
    /// </summary>
    public class SubscriptionServices
    {
        [Key]
        public Guid ServiceId { get; set; }
        public Guid SubscriptionId { get; set; }
        [JsonIgnore]
        public virtual Subscriptions Subscription { get; set; }
        public string ConfigJson { get; set; }
        public Guid EndPointId { get; set; }
    }
}
