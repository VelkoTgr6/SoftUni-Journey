
using Medicines.Common;
using Microsoft.Extensions.Primitives;
using System.ComponentModel.DataAnnotations;

namespace Medicines.Data.Models
{
    public class Pharmacy
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(ValidationConstrains.PharmacyNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber {  get; set; }

        [Required]
        public bool IsNonStop {  get; set; }

        public virtual ICollection<Medicine> Medicines { get; set; }
    }
}
