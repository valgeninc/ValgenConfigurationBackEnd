namespace ValgenConfigurationApp.Services.Models
{
    /// <summary>
    /// SubscriberRequestModel class.
    /// </summary>
    public class SubscriberRequestModel
    {
        public string UserName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? ConfigJSON { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? isActive { get; set; }
    }
}
