using Cadastre.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType("Property")]
    public class ImportPropertyDTO
    {
        [Required]
        [MinLength(ValidationConstants.PropertyIdentifierMinLength)]
        [MaxLength(ValidationConstants.PropertyIdentifierMaxLength)]
        public string PropertyIdentifier { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Area { get; set; }

        [MinLength(ValidationConstants.PropertyDetailsMinLegth)]
        [MaxLength(ValidationConstants.PropertyDetailsMaxLegth)]
        public string Details { get; set; }

        [Required]
        [MinLength(ValidationConstants.PropertyAddressMinLegth)]
        [MaxLength(ValidationConstants.PropertyAddressMaxLegth)]
        public string Address { get; set; }

        [Required]
        public string DateOfAcquisition { get; set; }
    }
}
