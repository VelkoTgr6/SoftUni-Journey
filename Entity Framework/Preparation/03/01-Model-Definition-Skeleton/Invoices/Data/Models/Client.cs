
using Invoices.Common;
using System.ComponentModel.DataAnnotations;

namespace Invoices.Data.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.ClientNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(ValidationConstants.ClientNumberVatMaxLength)]
        public string NumberVat { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<ProductClient> ProductsClients {  get; set; }
    }
}
