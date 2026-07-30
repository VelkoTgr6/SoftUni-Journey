

using System.ComponentModel.DataAnnotations;
using Trucks.Common;

namespace Trucks.Data.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.ClientNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength (ValidationConstants.ClientNationalityMaxLength)]
        public string Nationality {  get; set; }

        [Required]
        public string Type { get; set; }

        public virtual ICollection<ClientTruck> ClientsTrucks { get; set; }
    }
}
