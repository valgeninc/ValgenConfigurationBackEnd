namespace ValgenConfigurationApp.Models
{
    /// <summary>
    /// CompaniesAndContactAttributeResponseModel class.
    /// </summary>
    
    public class CompaniesAndContactAttributeResponseModel
    {
        public IEnumerable<string> contactFieldNames { get; set; }
        public IEnumerable<string> companyFieldNames { get; set; }
    }
}
