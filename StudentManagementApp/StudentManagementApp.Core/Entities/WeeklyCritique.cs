using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementApp.Core.Entities
{
    [Table("WeeklyCritiques")]
    public class WeeklyCritique : BaseEntity
    {
        // Link to trainee
        [ForeignKey("Trainee")]
        public required int TraineeId { get; set; }
        public virtual Trainee? Trainee { get; set; }

        // Criteria
        public string? PoliticalAttitude { get; set; }
        public int PAScore { get; set; }
        public string? StudyMotivation { get; set; }
        public int SMScore { get; set; }
        public string? EthicsLifestyle { get; set; }
        public int ELScore { get; set; }
        public string? DisciplineAwareness { get; set; }
        public int DAScore { get; set; }
        public string? AcademicResult { get; set; }
        public int ARScore { get; set; }
        public string? ResearchActivity { get; set; }
        public int RAScore { get; set; }

        public required int FinalScore { get; set; }
        public DateTime WeekDate { get; set; } // track which week
    }
}
