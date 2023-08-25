using System.Text.Json.Serialization;

namespace ValgenConfigurationApp.Services.Models
{
    /// <summary>
    /// SubscriberRequestModel class.
    /// </summary>
    public class SubscriberRequestModel
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        
    }
}
