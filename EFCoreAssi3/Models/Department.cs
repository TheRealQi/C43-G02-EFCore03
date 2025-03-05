using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreAssi3.Models
{
    public class Department
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = null!;

        [ForeignKey("Manager")]
        public int? Ins_ID { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        [DataType(DataType.Date)]
        public DateTime HiringDate { get; set; }
        
        
        [InverseProperty("ManagedDepartment")]
        public virtual Instructor Manager { get; set; } = null!;
        
        
        
        public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();
        
        
        [InverseProperty("Department")]
        public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
    }
}