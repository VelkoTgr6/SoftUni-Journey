

using Medicines.Common;
using Medicines.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Pharmacy")]
    public class ImportPharmacyDTO
    {
        [Required]
        [MinLength(ValidationConstrains.PharmacyNameMinLength)]
        [MaxLength(ValidationConstrains.PharmacyNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(ValidationConstrains.PharmacyPhoneRegex)]
        public string PhoneNumber { get; set; }

        [XmlAttribute("non-stop")]
        [Required]
        [RegularExpression(ValidationConstrains.PharmacyIsNonStopRegex)]
        public string IsNonStop { get; set; }

        [XmlArray(nameof(Medicines))]
        [XmlArrayItem("Medicine")]
        public ImportMedicineDTO[] Medicines { get; set; }
    }
}
