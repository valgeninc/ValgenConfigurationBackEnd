namespace ValgenConfigurationApp.Services.Models
{
    public class ColumnList
    {
        public List<string> AnonymizedColumnList { get; set; }
        public List<string> IdentifiedColumnList { get; set; }
    }

    public class TrackingDetailList
    {
        public int AnonymizedCompanyRecords { get; set; } = 0;

        public int AnonymizedLocationRecords { get; set; } = 0;

        public int IdentifiedCompanyRecords { get; set; } = 0;

        public int IdentifiedLocationRecords { get; set; } = 0;
    }

}
