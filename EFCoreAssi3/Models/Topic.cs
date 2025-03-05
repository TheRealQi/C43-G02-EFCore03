using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreAssi3.Models
{
    public class Topic
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; } = null!;
        
        public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();
    }
}