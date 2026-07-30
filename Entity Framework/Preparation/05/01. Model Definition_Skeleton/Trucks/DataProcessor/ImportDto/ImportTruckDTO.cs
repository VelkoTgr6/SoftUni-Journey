

using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Common;
using Trucks.Data.Models.Enums;

namespace Trucks.DataProcessor.ImportDto
{
    [XmlType("Truck")]
    public class ImportTruckDTO
    {
        [Required]
        [RegularExpression(ValidationConstants.TruckRegistrationNumberRegex)]
        public string RegistrationNumber { get; set; }

        [Required]
        [MaxLength(ValidationConstants.TruckVinMaxLength)]
        public string VinNumber { get; set; }

        [Range(ValidationConstants.TruckTankCapacityMinValue,ValidationConstants.TruckTankCapacityMaxValue)]
        public int TankCapacity { get; set; }

        [Range(ValidationConstants.TruckCargoCapacityMinValue,ValidationConstants.TruckCargoCapacityMaxValue)]
        public int CargoCapacity { get; set; }

        [Required]
        [Range(0,3)]
        public int CategoryType { get; set; }

        [Required]
        [Range(0,4)]
        public int MakeType { get; set; }
    }
}
