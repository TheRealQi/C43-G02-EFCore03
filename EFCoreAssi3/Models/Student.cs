using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreAssi3.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50, MinimumLength = 3)]
        public string FName { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50, MinimumLength = 3)]
        public string LName { get; set; } = null!;

        [MaxLength(100)]
        public string? Address { get; set; }

        [Required]
        [Range(18, 100)]
        public int Age { get; set; }

        [Required]
        [ForeignKey("Department")]
        public int Dep_ID { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
    }
}