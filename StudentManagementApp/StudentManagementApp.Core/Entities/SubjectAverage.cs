using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementApp.Core.Entities
{
    [Table("SubjectAverages")]
    public class SubjectAverage : BaseEntity
    {
        [Required]
        public required int SubjectId { get; set; }
        [Required]
        public required int TraineeId { get; set; }
        [Required]
        [Range(0.0, 10.0)]
        public required decimal Score { get; set; }
        [MaxLength(10)]
        public string? GradeType { get; set; }
        // Navigation
        public virtual Trainee? Trainee { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}
