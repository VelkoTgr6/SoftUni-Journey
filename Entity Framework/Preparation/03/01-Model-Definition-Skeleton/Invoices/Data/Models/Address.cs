

using Invoices.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Invoices.Data.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ValidationConstants.AddressStreetNameMaxLength)]
        public string StreetName { get; set; }

        [Required]
        public int StreetNumber {  get; set; }

        [Required]
        public string PostCode {  get; set; }

        [Required]
        [StringLength(ValidationConstants.AddressCountryNameMaxLength)]
        public string City { get; set; }

        [Required]
        [StringLength(ValidationConstants.AddressCountryNameMaxLength)]
        public string Country { get; set; }

        [Required]
        public int ClientId {  get; set; }

        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }

    }
}
