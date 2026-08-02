using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static DeskMarket.Constants.ModelConstants;

namespace DeskMarket.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        [Comment("Name of the Category")]
        public string Name { get; set; } = null!;

        public IList<Product> Products { get; set; }=new List<Product>();
    }
}
