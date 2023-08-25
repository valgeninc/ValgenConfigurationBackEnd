using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ValgenConfigurationApp.Models
{
    /// <summary>
    /// Create SubscriptionRequestModel class.
    /// </summary>
    public class CreateSubscriptionRequestModel
    {
        [Required]
        public Guid SubscriberId { get; set; }
        public Guid SubscriptionId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MaxRequests { get; set; }
        public int TimeWindow { get; set; }
        public bool IsActive { get; set; }
        public List<CreateSubscriptionServicesModel> CreateSubscriptionServicesModel { get; set; }
    }

    public class CreateSubscriptionServicesModel
    {
        public Guid ServiceId { get; set; }
        public string EndPointDesc { get; set; }
        public int CompanyRecords { get; set; }
        public int LocationRecords { get; set; }
        public int AdditionalCompanyRecords { get; set; }
        public int AdditionalLocationRecords { get; set; }
        public string[] Columns { get; set; }
    }
}
