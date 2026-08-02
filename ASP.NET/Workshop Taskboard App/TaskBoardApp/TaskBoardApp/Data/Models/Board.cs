using System.ComponentModel.DataAnnotations;

namespace TaskBoardApp.Data.Models
{
    public class Board
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DataConstants.BoardNameMaxLength)]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Task> Tasks { get; } = new List<Task>();
    }
}