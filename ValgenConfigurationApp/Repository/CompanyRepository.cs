using ValgenConfigurationApp.Repository.Models;

namespace ValgenConfigurationApp.Repository
{
    /// <summary>
    /// CompanyRepository class.
    /// </summary>

    public class CompanyRepository : ICompanyRepository
    {
        private DatabaseContext _databaseContext;
        public CompanyRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        // Method to get column names of Companies table.
        public async Task<IEnumerable<string>> GetCompanyAttributes()
        {
            var attributes = _databaseContext.Model.FindEntityType(typeof(Companies))?
                            .GetProperties()
                            .Select(p => p.Name)
                            .ToList();

            if (attributes == null)
            {
                throw new ArgumentException();
            }

            return await Task.FromResult(attributes);
        }
    }
}
