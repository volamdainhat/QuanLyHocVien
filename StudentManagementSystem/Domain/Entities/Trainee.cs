namespace StudentManagementSystem.Domain.Entities
{
    public class Trainee
    {
        public int Id { get; set; }
        // Required Information
        // Personal Information
        public string? FullName { get; set; }
        public DateTime? DayOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? IdentityCardNumber { get; set; }
        public string? Ranking { get; set; }
        public string? Ethnicity { get; set; }
        public string? StrongPoints { get; set; }
        public string? EnlistmentNotificationPlace { get; set; }
        public string? PlaceofOrigin { get; set; }

        // Education & Health
        public string? EducationLevel { get; set; }
        public string? HealthStatus { get; set; }

        // Family Information
        public string? FatherFullName { get; set; }
        public string? FatherPhoneNumber { get; set; }
        public string? MotherFullName { get; set; }
        public string? MotherPhoneNumber { get; set; }
        public string? ContactAddress { get; set; }
        
        // Military Service
        public string? MilitaryCode { get; set; }
        public DateTime? EnlistmentDate { get; set; }
        public string? EnlistmentProvince { get; set; }

        // Leave empty
        public string? Role { get; set; }
        
        // Academic & Performance
        public int MeritScore { get; set; }
        public string? ClassName { get; set; }
        public decimal? AverageScore { get; set; }
        public string? AvatarUrl { get; set; }

        // Navigation Properties
        public int? ClassId { get; set; }
        public Class? Class { get; set; }
        public ICollection<Grades> Grades { get; set; } = new List<Grades>();
        public ICollection<Misconduct> Misconducts { get; set; } = new List<Misconduct>();
        public ICollection<WeeklyCritique> WeeklyCritiques { get; set; } = new List<WeeklyCritique>();
    }
}