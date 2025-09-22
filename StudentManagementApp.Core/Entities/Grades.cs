using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementApp.Core.Entities
{
    [Table("Grades")]
    public class Grades : BaseEntity
    {
        [Required]
        [ForeignKey("Trainee")]
        public required int TraineeId { get; set; }
        [Required]
        [ForeignKey("Subject")]
        public required int SubjectId { get; set; }
        [Required]
        public required string ExamType { get; set; }
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải nằm trong khoảng từ 0 đến 10")]
        public decimal Grade { get; set; }
        // Navigation property
        public virtual Trainee? Trainee { get; set; }
        public virtual Subject? Subject { get; set; }
    }
}
