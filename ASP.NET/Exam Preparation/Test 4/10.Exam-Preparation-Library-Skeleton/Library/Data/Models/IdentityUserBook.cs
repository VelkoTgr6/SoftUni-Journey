using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Models
{
    public class IdentityUserBook
    {
        public string ColectorId { get; set; }

        [ForeignKey(nameof(ColectorId))]
        public IdentityUser Collector { get; set; } = null!;

        public int BookId {  get; set; }

        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; } = null!;
    }
}
