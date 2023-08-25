namespace ValgenConfigurationApp.Services.Models
{
    public class ColumnList
    {
        public List<string> AnonymizedColumnList { get; set; }
        public List<string> IdentifiedColumnList { get; set; }
    }

    public class Options {
        public string Label { get; set; }
        public string value { get; set; }
    }

}
