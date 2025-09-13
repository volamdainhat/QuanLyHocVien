namespace StudentManagementSystem.Domain.Entities
{
    public class Trainee
    {
        // This one is auto-increment
        public int Id { get; set; }
        // 'Họ và tên' - Required
        public string? FullName { get; set; }
        // 'Mã lớp '
        public int? ClassId { get; set; }
        // 'Tên lớp'
        public string? ClassName { get; set; }
        // 'SĐT' - Required
        public string? PhoneNumber { get; set; }
        // 'Ngày sinh' - Required
        public DateTime? DayOfBirth { get; set; }
        // 'Cấp bậc' - Required
        public string? Ranking { get; set; }
        // 'Nhập ngũ' - Required
        public DateTime? EnlistmentDate { get; set; }
        // 'ĐTB'
        public decimal? AverageScore { get; set; }
        // 'Chức vụ' - Required
        public string? Role { get; set; }
        // 'Họ tên cha' - Required
        public string? FatherFullName { get; set; }
        // 'SĐT cha' - Required
        public string? FatherPhoneNumber { get; set; }
        // 'Họ tên mẹ' - Required
        public string? MotherFullName { get; set; }
        // 'SĐT mẹ' - Required
        public string? MotherPhoneNumber { get; set; }
        // Empty for now
        public string? AvatarUrl { get; set; }
        public int MeritScore { get; set; } = 30;

        // Relations
        public ICollection<Grades> Grades { get; set; } = new List<Grades>();
        public ICollection<Misconduct> Misconducts { get; set; } = new List<Misconduct>();
    }
}
