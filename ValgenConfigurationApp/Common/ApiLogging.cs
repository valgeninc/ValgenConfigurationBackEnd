using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ValgenConfigurationApp.Repository.Models;

namespace ValgenConfigurationApp.Common
{
    public class ApiLogging
    {
        public static async Task InsertLog(string message, string messageType, Guid ownerId, DatabaseContext dbContext)
        {
            await dbContext.APILogs.AddAsync(new APILogs
            {
                Message = message,
                MessageType = messageType,
                OwnerId = ownerId,
                LoggedOn = DateTime.Now,
            });
            await dbContext.SaveChangesAsync();
        }
    }
}
