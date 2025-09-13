namespace StudentManagementSystem.Domain.Entities
{
    public class WeeklyCritique
    {
        public int Id { get; set; }

        // Link to trainee
        public int TraineeId { get; set; }
        public Trainee Trainee { get; set; } = null!;

        // Criteria
        public string? PoliticalAttitude { get; set; }
        public string? StudyMotivation { get; set; }
        public string? EthicsLifestyle { get; set; }
        public string? DisciplineAwareness { get; set; }
        public string? AcademicResult { get; set; }
        public string? ResearchActivity { get; set; }

        public int FinalScore { get; set; }
        public DateTime WeekDate { get; set; } // track which week
    }
}
