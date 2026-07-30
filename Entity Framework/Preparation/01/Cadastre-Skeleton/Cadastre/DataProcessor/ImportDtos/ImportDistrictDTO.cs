using Cadastre.Common;
using Cadastre.Data.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType("District")]
    public class ImportDistrictDTO
    {
        [XmlAttribute(nameof(Region))]
        [Required]
        public Region Region { get; set; }

        [Required]
        [MaxLength(ValidationConstants.DistrictNameMaxLength)]
        [MinLength(ValidationConstants.DistrictNameMinLength)]
        public string Name { get; set; }

        [Required]
        public string PostalCode { get; set; }

        [XmlArray(nameof(Properties))]
        [XmlArrayItem("Property")]
        public virtual ImportPropertyDTO[] Properties { get; set; }
    }
}
