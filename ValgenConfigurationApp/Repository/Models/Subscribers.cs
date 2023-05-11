namespace ValgenConfigurationApp.Repository.Models
{
    /// <summary>
    /// Subscribers class.
    /// </summary>
    
    public class Subscribers
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Token { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set;}
        public string? ConfigJSON { get; set; }
        public bool? isActive { get; set; }
    }
}
