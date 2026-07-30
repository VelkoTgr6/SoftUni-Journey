
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using TravelAgency.Common;

namespace TravelAgency.DataProcessor.ImportDtos
{
    [XmlType("Customer")]
    public class ImportCustomerDTO
    {
        [Required]
        [XmlAttribute("phoneNumber")]
        [RegularExpression(ValidationConstants.CustomerPhoneRegex)]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(ValidationConstants.CustomerFullNameMinLength)]
        [MaxLength(ValidationConstants.CustomerFullNameMaxLength)]
        public string FullName { get; set; }

        [Required]
        [MinLength(ValidationConstants.CustomerEmailMinLength)]
        [MaxLength(ValidationConstants.CustomerEmailMaxLength)]
        public string Email { get; set; }

        
    }
}
