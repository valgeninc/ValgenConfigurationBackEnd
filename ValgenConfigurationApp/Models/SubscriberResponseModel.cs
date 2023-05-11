namespace ValgenConfigurationApp.Models
{
    /// <summary>
    /// SubscribeResponseModel class.
    /// </summary>
    
    public class SubscriberResponseModel
    {
        // Subscribers's Id.
        public Guid Id { get; set; }

        // Subscribers's UserName.
        public string UserName { get; set; } = string.Empty;

        // Subscribers's Email.
        public string? Email { get; set; }

        // Subscribers's Phone.
        public string? Phone { get; set; }

        // Subscriber's Token.
        public string? SubscriberToken { get; set; }

        // Subscriber's StartDate.
        public DateTime? StartDate { get; set; }

        // Subscriber's Enddate.
        public DateTime? EndDate { get; set; }

        // Subscriber's ConfigJSON.
        public string? ConfigJSON { get; set; }

        // This checks wheather a subscriber is active or not.
        public bool? IsActive { get; set; }
    }
}
