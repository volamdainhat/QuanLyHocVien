using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementApp.Core.Entities
{
    [Table("TraineeAverageScores")]
    public class TraineeAverageScore : BaseEntity
    {
        [Required]
        [ForeignKey("Trainee")]
        public required int TraineeId { get; set; }
        //[Required]
        //[ForeignKey("Semester")]
        //public required int SemesterId { get; set; }
        [Required]
        [Range(0.0, 10.0)]
        public required decimal AverageScore { get; set; }
        [MaxLength(20)]
        public string? GradeType { get; set; }
        // Navigation property
        public virtual Trainee? Trainee { get; set; }
        public virtual Semester? Semester { get; set; }
    }
}
