namespace ValgenConfigurationApp.Repository.Models
{
    public class ServicesTracking
    {
        public Guid SubscriptionId { get; set; }
        public Guid EndPointId { get; set; }
        public string RecordType { get; set; }
        public string? RecordsId { get; set; }
        public int TotalRecordsFetched { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
