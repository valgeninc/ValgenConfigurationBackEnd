using System.ComponentModel.DataAnnotations;

namespace ValgenConfigurationApp.Models
{
    /// <summary>
    /// CreateSubscriberRequestModel class.
    /// </summary>
    
    public class CreateSubscriberRequestModel
    {
        // Subscriber's Username.
        [Required,MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        // Subscriber's Email.
        [MaxLength(50)]
        public string? Email { get; set;}

        // Subscriber's Phone.
        [MaxLength(20)]
        public string? Phone { get; set;}

        //// Subscriber's ConfigJson.
        //public string? ConfigJSON { get; set;}

        //// Subscriber's Start Date.
        //public DateTime? StartDate { get; set; }

        //// Subscriber's End Date.
        //public DateTime? EndDate { get; set; }

        //// This checks if subscriber is active or not.
        //public bool? isActive { get; set; }
    }
}
