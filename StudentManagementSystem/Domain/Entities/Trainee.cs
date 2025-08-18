namespace StudentManagementSystem.Domain.Entities
{
    public class Trainee
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public int ClassId { get; set; }
        public string? ClassName { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DayOfBirth { get; set; }
        public string? Ranking { get; set; }
        public DateTime? EnlistmentDate { get; set; }
        public decimal? AverageScore { get; set; }
        public string? Role { get; set; }
        public string? FatherFullName { get; set; }
        public string? FatherPhoneNumber { get; set; }
        public string? MotherFullName { get; set; }
        public string? MotherPhoneNumber { get; set; }
        public string? AvatarUrl { get; set; }
    }
}
