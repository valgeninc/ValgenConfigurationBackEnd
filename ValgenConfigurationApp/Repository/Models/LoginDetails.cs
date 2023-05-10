namespace ValgenConfigurationApp.Services.Models
{
    /// <summary>
    /// LoginDetailsModel class.
    /// </summary>
    
    public class LoginDetails
    {
        public int Id { get; set; }
        public string userName { get; set; } = string.Empty;
        public string? userPassword { get; set; }
    }
}
