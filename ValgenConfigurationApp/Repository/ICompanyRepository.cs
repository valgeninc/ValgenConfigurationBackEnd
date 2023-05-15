namespace ValgenConfigurationApp.Repository
{
    /// <summary>
    /// ICompanyRepository class.
    /// </summary>
    
    public interface ICompanyRepository
    {
        public Task<IEnumerable<string>> GetCompanyAttributes();
    }
}
