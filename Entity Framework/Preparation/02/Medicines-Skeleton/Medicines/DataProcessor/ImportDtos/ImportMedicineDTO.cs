using Medicines.Common;
using Medicines.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Medicine")]
    public class ImportMedicineDTO
    {
        [XmlAttribute("category")]
        [Required]
        [Range(ValidationConstrains.MedicineCategoryMinValue,ValidationConstrains.MedicineCategoryMaxValue)]
        public int Category { get; set; }

        [Required]
        [MinLength(ValidationConstrains.MedicineNameMinLength)]
        [MaxLength(ValidationConstrains.MedicineNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [Range(ValidationConstrains.MedicinePriceMin,ValidationConstrains.MedicinePriceMax)]
        public decimal Price { get; set; }

        [Required]
        public string ProductionDate { get; set; }

        [Required]
        public string ExpiryDate { get; set; }

        [Required]
        [MinLength(ValidationConstrains.MedicineProducerMin)]
        [MaxLength(ValidationConstrains.MedicineProducerMax)]
        public string Producer { get; set; }
    }
}
