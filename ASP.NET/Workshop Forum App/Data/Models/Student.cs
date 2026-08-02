using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static StudentManagement.Constants.ModelConstants;

namespace StudentManagement.Data.Models
{
    public class Student
    {
        [Key]
        [Comment("Student Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(StudentNameMaxLength)]
        [Comment("Student Name")]
        public string Name { get; set; } = null!;

        [Required]
        [Comment("Date of birth of Student")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(StudentContactMaxLength)]
        [Comment("Student Contact Details")]
        public string ContactDetails {  get; set; }= null!;

        [Comment("Courses that student enroled")]
        public ICollection<Course> CoursesEnrolled { get; set; } = new List<Course>();

        [Comment("Student Performance")]
        public double Performance {  get; set; }

        [Comment("Collection of Grades assigned to the student")]
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}
