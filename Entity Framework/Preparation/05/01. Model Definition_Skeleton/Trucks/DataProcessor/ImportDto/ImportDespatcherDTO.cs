

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Common;
using Trucks.Data.Models;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Despatcher")]
    public class ImportDespatcherDTO
    {
        [Required]
        [MinLength(ValidationConstants.DespatcherNameMinLength)]
        [MaxLength(ValidationConstants.DespatcherNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(1)]
        public string Position { get; set; }

        [XmlArray("Trucks")]
        [XmlArrayItem("Truck")]
        public ImportTruckDTO[] Trucks { get; set; }
    }
}
