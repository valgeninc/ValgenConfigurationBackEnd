using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ValgenConfigurationApp.Repository.Models;

namespace ValgenConfigurationApp.Services.Models
{
    public class SubscriptionModel
    {
        public Guid SubscriptionId { get; set; }
        public Guid SubscriberId { get; set; }
        public string? SubscriberToken { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MaxRequests { get; set; }
        public int TimeWindow { get; set; }
        public bool? isActive { get; set; }
        public List<SubscriptionServicesModel> SubscriptionServicesModel { get; set; }
    }

    public class SubscriptionServicesModel
    {
        public Guid ServiceId { get; set; }
        public Guid SubscriptionId { get; set; }
        public int CompanyRecords { get; set; }
        public int LocationRecords { get; set; }
        public string EndPointDesc { get; set; }
        public string[] Columns { get; set; }
        public int RemainingCompanyRecords { get; set; }
        public int RemainingLocationRecords { get; set; }
    }
    public class SubscriptionServicesDeserialized
    {
        public int CompanyRecords { get; set; }
        public int LocationRecords { get; set; }
        public string[] Columns { get; set; }
    }
}

