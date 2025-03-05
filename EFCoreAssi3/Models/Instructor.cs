using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreAssi3.Models
{
    public class Instructor
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        public int? Bonus { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Salary { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string? Address { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal HourRate { get; set; }

        [Required]
        [ForeignKey("Department")]
        public int Dept_ID { get; set; }

        public virtual Department Department { get; set; } = null!;
        
        [InverseProperty("Manager")]
        public virtual Department ManagedDepartment { get; set; } = null!;
        
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; } = new HashSet<CourseInstructor>();
    }
}