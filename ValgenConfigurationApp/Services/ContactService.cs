using ValgenConfigurationApp.Repository;
using ValgenConfigurationApp.Services.Models;

namespace ValgenConfigurationApp.Services
{
    /// <summary>
    /// ContactService class.
    /// </summary>
    
    public class ContactService : IContactService
    {
        private IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IEnumerable<string>> ContactAttributes()
        {
            return await _contactRepository.GetContactsAttributes();
        }
    }
}
