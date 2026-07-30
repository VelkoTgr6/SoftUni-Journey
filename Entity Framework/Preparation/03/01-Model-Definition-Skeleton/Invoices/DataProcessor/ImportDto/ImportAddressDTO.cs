

using Invoices.Common;
using System.ComponentModel.DataAnnotations;

namespace Invoices.DataProcessor.ImportDto
{
    public class ImportAddressDTO
    {

        [Required]
        [MinLength(ValidationConstants.AddressStreetNameMinLength)]
        [MaxLength(ValidationConstants.AddressStreetNameMaxLength)]
        public string StreetName { get; set; }

        [Required]
        public int StreetNumber { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        [MinLength(ValidationConstants.AddressCityNameMinLength)]
        [MaxLength(ValidationConstants.AddressCountryNameMaxLength)]
        public string City { get; set; }

        [Required]
        [MinLength(ValidationConstants.AddressCountryNameMinLength)]
        [MaxLength(ValidationConstants.AddressCountryNameMaxLength)]
        public string Country { get; set; }
    }
}
