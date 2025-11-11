using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementApp.Core.Entities
{
    public class PracticePoint : BaseEntity
    {
        [Required]
        [ForeignKey("PracticePoints")]
        public required int TraineeId { get; set; }
        [Required]
        public required string Content { get; set; }
        [Required]
        public required decimal Point { get; set; }
        [Required]
        public required DateTime Time { get; set; }
        public string? Description { get; set; }
        // Navigation property
        public virtual Trainee? Trainee { get; set; }
    }
}
