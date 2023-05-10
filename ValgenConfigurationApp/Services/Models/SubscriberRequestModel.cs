using Microsoft.VisualBasic;

namespace ValgenConfigurationApp.Services.Models
{
    public class SubscriberRequestModel
    {
        public string UserName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? ConfigJSON { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
