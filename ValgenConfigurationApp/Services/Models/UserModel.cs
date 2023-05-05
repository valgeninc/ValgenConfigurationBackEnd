namespace ValgenConfigurationApp.Services.Models
{
    /// <summary>
    /// UserModel class.
    /// </summary>

    public class UserModel
    {
        public int Id { get; set; }
        public string userName { get; set; } = string.Empty;
        public string? userPassword { get; set; }
    }
}
