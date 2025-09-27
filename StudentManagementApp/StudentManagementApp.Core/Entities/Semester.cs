using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementApp.Core.Entities
{
    public class Semester : BaseEntity
    {
        [ForeignKey("SchoolYear")]
        public int SchoolYearId { get; set; }
        [Required]
        [StringLength(50)]
        public required string Name { get; set; } // Ví dụ: "Học kỳ I", "Học kỳ II"
        [Required]
        public required DateTime StartDate { get; set; }
        [Required]
        public required DateTime EndDate { get; set; }
        // Navigation property
        public virtual SchoolYear? SchoolYear { get; set; }
    }
}
