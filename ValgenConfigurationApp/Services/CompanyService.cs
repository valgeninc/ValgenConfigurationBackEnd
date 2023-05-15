using ValgenConfigurationApp.Repository;

namespace ValgenConfigurationApp.Services
{
    /// <summary>
    /// CompanyService class.
    /// </summary>
    
    public class CompanyService : ICompanyService
    {
        private ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<string>> CompanyAttributes()
        {
            return await _companyRepository.GetCompanyAttributes();
        }
    }
}
