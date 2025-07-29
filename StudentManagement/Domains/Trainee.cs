namespace QuanLyHocVien.Domain.Entities
{
    public class Trainee
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required int ClassId { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? DayOfBirth { get; set; }
        public required string Ranking { get; set; }
        public required DateTime EnlistmentDate { get; set; }
        public float? AverageScore { get; set; }
        public required string Role { get; set; } = "Học viên";
        public string? FatherFullName { get; set; }
        public string? FatherPhoneNumber { get; set; }
        public string? MotherFullName { get; set; }
        public string? MotherPhoneNumber { get; set; }
    }
}
