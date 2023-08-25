using System.ComponentModel.DataAnnotations;

namespace ValgenConfigurationApp.Repository.Models
{
    public class APILogs
    {
        [Key]
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string MessageType { get; set; }
        public string Message { get; set; }
        public DateTime LoggedOn { get; set; }
    }
}
