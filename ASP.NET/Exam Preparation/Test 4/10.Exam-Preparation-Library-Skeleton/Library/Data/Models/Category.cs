using System.ComponentModel.DataAnnotations;
using static Library.Data.Constants.DataConstants;
namespace Library.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Book> Books { get; set; }=new List<Book>();
    }
}
