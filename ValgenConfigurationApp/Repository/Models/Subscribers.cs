namespace ValgenConfigurationApp.Repository.Models
{
    /// <summary>
    /// Subscribers class.
    /// </summary>
    
    public class Subscribers
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public ICollection<Subscriptions> Subscriptions { get; }
    }
}
