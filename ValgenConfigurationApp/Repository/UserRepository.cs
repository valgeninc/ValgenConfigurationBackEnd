using Microsoft.EntityFrameworkCore;
using ValgenConfigurationApp.Repository.Models;
using ValgenConfigurationApp.Services.Models;

namespace ValgenConfigurationApp.Repository
{
    /// <summary>
    /// UserRepository class getting data from database.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            if (databaseContext == null)
                throw new ArgumentNullException(nameof(databaseContext));

            _databaseContext = databaseContext;
        }

        // Method for getting user details from Database.
        public async Task<UserModel> GetUser(string username, string password)
        {
            var res = await _databaseContext.LoginDetails.FirstOrDefaultAsync(u => u.userName == username && u.userPassword == password);
            if (res == null)
                return null!;
            return ToUserModel( res );
        }

        // Method for mapping LoginDetailsModel to UserModel.
        private UserModel ToUserModel(LoginDetails model) {
            return new UserModel()
            {
                Id = model.Id,
                userName = model.userName,
                userPassword = model.userPassword
            };
        }
    }
}
