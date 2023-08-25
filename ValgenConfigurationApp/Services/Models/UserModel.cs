namespace ValgenConfigurationApp.Services.Models
{
    /// <summary>
    /// UserModel class.
    /// </summary>

    public class UserModel
    {
        public Guid Id { get; set; }
        public string userName { get; set; } = string.Empty;
        public string? userPassword { get; set; }
    }
}
