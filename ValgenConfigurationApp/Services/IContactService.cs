namespace ValgenConfigurationApp.Services
{
    /// <summary>
    /// IContactService Interface.
    /// </summary>

    public interface IContactService
    {
        public Task<IEnumerable<string>> ContactAttributes();
    }
}
