namespace ValgenConfigurationApp.Models
{
    /// <summary>
    /// CreateSubscriberRequestModel class.
    /// </summary>
    
    public class CreateSubscriberRequestModel
    {
        // Subscriber's Username.
        public string SubscriberUserName { get; set; } = string.Empty;

        // Subscriber's Email.
        public string? SubscriberEmail { get; set;}

        // Subscriber's Phone.
        public string? SubscriberPhone { get; set;}

        // Subscriber's ConfigJson.
        public string? ConfigJSON { get; set;}

        // Subscriber's Start Date.
        public DateTime? StartDate { get; set; }

        // Subscriber's End Date.
        public DateTime? EndDate { get; set; }

        // This checks if subscriber is active or not.
        public bool? isActive { get; set; }
    }
}
