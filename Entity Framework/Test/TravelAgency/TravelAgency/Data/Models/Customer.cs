

using System.ComponentModel.DataAnnotations;
using TravelAgency.Common;

namespace TravelAgency.Data.Models
{ 
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CustomerFullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CustomerEmailMaxLength)]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
