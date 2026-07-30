using Boardgames.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Data.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Required]
        [StringLength(ValidationConstants.SellerNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(ValidationConstants.SellerAddressMaxLength)]
        public string Address {  get; set; }

        [Required]
        public string Country {  get; set; }

        [Required]
        public string Website {  get; set; }

        public virtual ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
    }
}
