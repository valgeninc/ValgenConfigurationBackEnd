namespace ValgenConfigurationApp.Services.Models
{
    /// <summary>
    /// SubscriberModel class.
    /// </summary>

    public class SubscriberModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? SubscriberToken { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set;}
        public string? ConfigJSON { get; set; }
    }
}
