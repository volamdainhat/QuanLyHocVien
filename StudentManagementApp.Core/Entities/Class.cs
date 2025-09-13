using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementApp.Core.Entities
{
    [Table("Classes")]
    public class Class : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }
        [ForeignKey("SchoolYear")]
        public int SchoolYearId { get; set; }
        public int TotalStudents { get; set; }
        // Navigation property
        public virtual SchoolYear? SchoolYear { get; set; }
    }
}
