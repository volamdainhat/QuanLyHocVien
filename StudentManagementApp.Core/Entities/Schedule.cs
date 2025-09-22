using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementApp.Core.Entities
{
    [Table("Schedules")]
    public class Schedule : BaseEntity
    {
        [Required]
        [ForeignKey("Class")]
        public required int ClassId { get; set; }
        [Required]
        [ForeignKey("Subject")]
        public required int SubjectId { get; set; }
        [Required]
        public required string Room { get; set; }
        [Required]
        public required string Period { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public required DateTime Date { get; set; }
        // Navigation property
        public virtual Class? Class { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}
