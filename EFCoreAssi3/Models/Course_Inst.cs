using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreAssi3.Models
{
    public class CourseInstructor
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Instructor")]
        public int Inst_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Course")]
        public int Course_ID { get; set; }

        [Range(1, 100)]
        public int? Evaluate { get; set; }

        public virtual Instructor Instructor { get; set; } = null!;
        public virtual Course Course { get; set; } = null!;
    }
}