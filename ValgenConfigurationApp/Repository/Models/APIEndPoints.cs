using System.ComponentModel.DataAnnotations;

namespace ValgenConfigurationApp.Repository.Models
{
    public class APIEndPoints
    {
        [Key]
        public Guid EndPointId { get; set; }
        public string EndPointDesc { get; set; }
    }
}
