using System.ComponentModel;

namespace StudentManagementApp.Core.Models.Trainees
{
    public class TraineeViewModel
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("Họ và tên")]
        public string? FullName { get; set; }
        [DisplayName("Lớp")]
        public string? ClassName { get; set; }
        [DisplayName("SĐT")]
        public string? PhoneNumber { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime DayOfBirth { get; set; }
        [DisplayName("Cấp bậc")]
        public string? MilitaryRank { get; set; }
        [DisplayName("Nhập ngũ")]
        public DateTime EnlistmentDate { get; set; }
        [DisplayName("Điểm TB")]
        public decimal AverageScore { get; set; }
        [DisplayName("Chức vụ")]
        public string? Role { get; set; }
        [DisplayName("Họ tên cha")]
        public string? FatherFullName { get; set; }
        [DisplayName("SĐT cha")]
        public string? FatherPhoneNumber { get; set; }
        [DisplayName("Họ tên mẹ")]
        public string? MotherFullName { get; set; }
        [DisplayName("SĐT mẹ")]
        public string? MotherPhoneNumber { get; set; }
        [Browsable(false)]
        public string? AvatarUrl { get; set; }
        [DisplayName("Điểm rèn luyện")]
        public int MeritScore { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [DisplayName("Ngày cập nhật")]
        public DateTime? ModifiedDate { get; set; }
        [DisplayName("Đang hoạt động")]
        public bool IsActive { get; set; } = true;
    }
}
