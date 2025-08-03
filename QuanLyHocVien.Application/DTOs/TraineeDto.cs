using System.ComponentModel;

namespace QuanLyHocVien.Applications.DTOs
{
    public class TraineeDto
    {
        public class ViewModel
        {
            [Browsable(false)]
            public int Id { get; set; }

            [DisplayName("Họ và tên")]
            public required string FullName { get; set; }

            [DisplayName("Lớp")]
            public required int ClassId { get; set; }

            [DisplayName("Họ và tên")]
            public required string ClassName { get; set; }

            [DisplayName("Số điện thoại")]
            public string? PhoneNumber { get; set; }

            [DisplayName("Ngày sinh")]
            public DateTime? DayOfBirth { get; set; }

            [DisplayName("Cấp bậc")]
            public required string Ranking { get; set; }

            [DisplayName("Ngày nhập ngũ")]
            public required DateTime EnlistmentDate { get; set; }

            [DisplayName("Điêm trung bình")]
            public float? AverageScore { get; set; }

            [DisplayName("Vai trò")]
            public required string Role { get; set; } = "Học viên";

            [DisplayName("Họ tên cha")]
            public string? FatherFullName { get; set; }

            [DisplayName("Số điện thoại cha")]
            public string? FatherPhoneNumber { get; set; }

            [DisplayName("Họ tên mẹ")]
            public string? MotherFullName { get; set; }

            [DisplayName("Số điẹnt thoại mẹ")]
            public string? MotherPhoneNumber { get; set; }
        }
    }
}
