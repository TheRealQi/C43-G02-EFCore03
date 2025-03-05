using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreAssi3.Models
{
    public class StudentCourse
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Student")]
        public int Stud_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Course")]
        public int Course_ID { get; set; }

        [Required]
        [Column(TypeName = "char")]
        [StringLength(2)] // A+, A, A-, B+, B, B-, C+, C, C-, D+, D, D-, F
        public string Grade { get; set; } = null!;

        public virtual Student Student { get; set; } = null!;
        public virtual Course Course { get; set; } = null!;
    }
}