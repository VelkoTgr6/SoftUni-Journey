using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Trucks.Common;
using Trucks.Data.Models.Enums;

namespace Trucks.Data.Models
{
    public class Truck
    {
        public int Id { get; set; }
        public string RegistrationNumber { get; set; }

        [Required]
        [MaxLength(ValidationConstants.TruckVinMaxLength)]
        public string VinNumber {  get; set; }
        public int TankCapacity {  get; set; }
        public int CargoCapacity { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; }

        [Required]
        public MakeType MakeType { get; set; }

        [Required]
        public int DespatcherId {  get; set; }

        [ForeignKey(nameof(DespatcherId))]
        public virtual Despatcher Despatcher { get; set; }

        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }

    }
}
