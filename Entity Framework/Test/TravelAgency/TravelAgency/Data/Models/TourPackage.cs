

using System.ComponentModel.DataAnnotations;
using TravelAgency.Common;

namespace TravelAgency.Data.Models
{
    public class TourPackage
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(ValidationConstants.PackageNameMaxLength)]
        public string PackageName { get; set; }

        [MaxLength(ValidationConstants.TourDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [Range(0,double.MaxValue)]
        public decimal Price { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual ICollection<TourPackageGuide> TourPackagesGuides { get; set; }
    }
}
