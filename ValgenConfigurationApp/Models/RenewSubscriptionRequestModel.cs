namespace ValgenConfigurationApp.Models
{
    public class RenewSubscriptionRequestModel
    {
        public Guid SubscriptionId { get; set; }
        public bool IsActive { get; set; }
    }
}
