namespace ValgenConfigurationApp.Repository
{
    /// <summary>
    /// IContactRepository class.
    /// </summary>

    public interface IContactRepository
    {
        public Task<IEnumerable<string>> GetContactsAttributes();
    }
}
