using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static StudentManagement.Constants.ModelConstants;

namespace StudentManagement.Data.Models
{
    public class Teacher
    {
        [Key]
        [Comment("Teacher Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(TeacherNameMaxLength)]
        [Comment("Teacher Name")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(TeacherContactMaxLength)]
        [Comment("Teacher Contact Details")]
        public string ContactDetails { get; set; } = null!;

        [Comment("Teacher Assigned Courses")]
        public ICollection<Course> Courses { get; set; }=new List<Course>();
    }
}
