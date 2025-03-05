using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreAssi3.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }
        
        [Required]
        [Range(1, 12)]
        public int Duration { get; set; }
        
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = null!;
        
        [Column(TypeName = "varchar")]
        [StringLength(200)]
        public string? Description { get; set; }
        
        [Required]
        [ForeignKey("Topic")]
        public int Top_ID { get; set; }
        
        public virtual Topic Topic { get; set; } = null!;
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; } = new HashSet<CourseInstructor>();
    }
}