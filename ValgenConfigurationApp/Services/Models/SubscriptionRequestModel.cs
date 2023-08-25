using Newtonsoft.Json;

namespace ValgenConfigurationApp.Services.Models
{
    /// <summary>
    /// SubscriptionRequestModel class.
    /// </summary>
    public class SubscriptionRequestModel
    {
        public DateTime? EndDate { get; set; }
        public bool? IsActive { get; set; }
        public int MaxRequests { get; set; }
        public Guid SubscriptionId { get; set; }
        public Guid SubscriberId { get; set; }
        public DateTime? StartDate { get; set; }
        public List<SubscriptionServiceModel> SubscriptionServiceModel { get; set; }
        public List<SubscriptionServicesMainModel> SubscriptionServicesMainModel { get; set; }
        public string SubscriberToken { get; set; }
        public int TimeWindow { get; set; }
        [JsonIgnore]
        public Guid RefreshTokenId { get; set; }
    }
    public class SubscriptionServicesMainModel
    {
        public Guid ServiceId { get; set; }
        public string EndPointDesc { get; set; }
        public string ConfigJson { get; set; }
        public int AdditionalCompanyRecords { get; set; }
        public int AdditionalLocationRecords { get; set; }
    }

    public class SubscriptionServiceModel
    {
        public int CompanyRecords { get; set; }
        public int LocationRecords { get; set; }
        public string[] Columns { get; set; }
    }
}
