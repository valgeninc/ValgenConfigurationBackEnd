using ValgenConfigurationApp.Repository.Models;

namespace ValgenConfigurationApp.Repository
{
    /// <summary>
    /// ContactRepository class.
    /// </summary>

    public class ContactRepository : IContactRepository
    {
        private DatabaseContext _databaseContext;
        public ContactRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        
        // Method to get column names of Contacts table.
        public async Task<IEnumerable<string>> GetContactsAttributes()
        {
            var attributes = _databaseContext.Model.FindEntityType(typeof(Contacts))?
                            .GetProperties()
                            .Select(p => p.Name)
                            .ToList();
            if(attributes == null) {
                throw new ArgumentException();
            }
          
            return await Task.FromResult(attributes);
        }
    }
}
