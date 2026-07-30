using Cadastre.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre.Data.Models
{
    public class Property
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.PropertyIdentifierMaxLength)]
        public string PropertyIdentifier {  get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int Area { get; set; }

        [MaxLength(ValidationConstants.PropertyDetailsMaxLegth)]
        public string Details {  get; set; }

        [Required]
        [MaxLength(ValidationConstants.PropertyAddressMaxLegth)]
        public string Address {  get; set; }

        [Required]
        public DateTime DateOfAcquisition { get; set; }

        [Required]
        public int DistrictId {  get; set; }

        [ForeignKey(nameof(DistrictId))]
        public virtual District District { get; set; }

        public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; }
    }
}
