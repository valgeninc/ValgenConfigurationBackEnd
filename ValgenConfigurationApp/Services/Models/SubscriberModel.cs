namespace ValgenConfigurationApp.Services.Models
{
    /// <summary>
    /// SubscriberModel class.
    /// </summary>

    public class SubscriberModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
