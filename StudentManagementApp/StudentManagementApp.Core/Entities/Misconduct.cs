using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementApp.Core.Entities
{
    public class Misconduct : BaseEntity
    {
        [Required]
        [ForeignKey("Trainee")]
        public required int TraineeId { get; set; }
        [Required]
        public required string Type { get; set; }
        [Required]
        public required DateTime Time { get; set; }
        public string? Description { get; set; }
        // Navigation property
        public virtual Trainee? Trainee { get; set; }
    }
}
