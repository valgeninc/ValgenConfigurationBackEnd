using Microsoft.AspNetCore.Mvc;
using ValgenConfigurationApp.Models;
using ValgenConfigurationApp.Services;

namespace ValgenConfigurationApp.Controllers
{
    /// <summary>
    /// CompaniesController class.
    /// </summary>

    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private IContactService _contactService;
        private ICompanyService _companyService;
        public CompaniesController(IContactService contactService, ICompanyService companyService)
        {
            _contactService = contactService;
            _companyService = companyService;
        }

        /// <summary>
        /// Getting column name of companies and contacts table
        /// </summary>
        /// <returns>column names</returns>
        /// <exception cref="Exception">throws when API failed</exception>
        
        [HttpGet]
        public async Task<CompaniesAndContactAttributeResponseModel> GetAttributes()
        {
            var contactModel = await _contactService.ContactAttributes();
            var companyModel = await _companyService.CompanyAttributes();
            return ToModel(contactModel, companyModel);
        }

        // Method to convert into CompaniesAndContactAttributeResponseModel.
        private CompaniesAndContactAttributeResponseModel ToModel(IEnumerable<string> contactModel, IEnumerable<string> companyModel)
        {
            return new CompaniesAndContactAttributeResponseModel
            {
                contactFieldNames = contactModel,
                companyFieldNames = companyModel
            };
        }
    }
}
