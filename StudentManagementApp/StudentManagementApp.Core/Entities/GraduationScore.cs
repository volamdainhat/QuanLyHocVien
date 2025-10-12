using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementApp.Core.Entities
{
    [Table("GraduationScores")]
    public class GraduationScore : BaseEntity
    {
        [Required]
        [ForeignKey("Trainee")]
        public required int TraineeId { get; set; }
        [Required]
        [Range(0.0, 10.0)]
        public required decimal Score { get; set; }
        [MaxLength(20)]
        public string? GraduationType { get; set; }
        // Navigation property
        public virtual Trainee? Trainee { get; set; }
    }
}
