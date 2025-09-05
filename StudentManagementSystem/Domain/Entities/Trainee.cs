namespace StudentManagementSystem.Domain.Entities
{
    public class Trainee
    {
        // This one is auto-increment
        public int Id { get; set; }
        // 'Họ và tên'
        public string? FullName { get; set; }
        // 'Mã lớp '
        public int ClassId { get; set; }
        // 'Tên lớp'
        public string? ClassName { get; set; }
        // 'SĐT'
        public string? PhoneNumber { get; set; }
        // 'Ngày sinh'
        public DateTime? DayOfBirth { get; set; }
        // 'Cấp bậc'
        public string? Ranking { get; set; }
        // 'Nhập ngũ'
        public DateTime? EnlistmentDate { get; set; }
        // 'ĐTB'
        public decimal? AverageScore { get; set; }
        // 'Chức vụ'
        public string? Role { get; set; }
        // 'Họ tên cha'
        public string? FatherFullName { get; set; }
        // 'SĐT cha'
        public string? FatherPhoneNumber { get; set; }
        // 'Họ tên mẹ'
        public string? MotherFullName { get; set; }
        // 'SĐT mẹ'
        public string? MotherPhoneNumber { get; set; }
        // Empty for now
        public string? AvatarUrl { get; set; }

        // Relations
        public ICollection<Grades> Grades { get; set; } = new List<Grades>();
        public ICollection<Misconduct> Misconducts { get; set; } = new List<Misconduct>();
    }
}
