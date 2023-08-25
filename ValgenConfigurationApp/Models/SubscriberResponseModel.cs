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
        public string Name { get; set; } = string.Empty;

        // Subscribers's Email.
        public string? Email { get; set; }

        // Subscribers's Phone.
        public string? Phone { get; set; }
    }
}
