namespace ValgenConfigurationApp.Services
{
    /// <summary>
    /// ICompanyService class.
    /// </summary>

    public interface ICompanyService
    {
        public Task<IEnumerable<string>> CompanyAttributes();
    }
}
