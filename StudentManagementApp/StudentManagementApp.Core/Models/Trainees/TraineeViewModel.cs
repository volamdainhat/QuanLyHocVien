using System.ComponentModel;

namespace StudentManagementApp.Core.Models.Trainees
{
    public class TraineeViewModel
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("Họ và tên")]
        public string? FullName { get; set; }
        [Browsable(false)] // Ẩn ClassId nhưng vẫn giữ để lọc
        public int? ClassId { get; set; }
        [DisplayName("Lớp")]
        public string? ClassName { get; set; }
        [DisplayName("Ngày sinh")]
        public DateTime DayOfBirth { get; set; }
        [DisplayName("Giới tính Nam")]
        public bool Gender { get; set; }
        [DisplayName("Căn cước")]
        public string? IdentityCard { get; set; }
        [DisplayName("Dân tộc")]
        public string? Ethnicity { get; set; }
        [DisplayName("Nguyên quán")]
        public string PlaceOfOrigin { get; set; }
        [DisplayName("Thường trú")]
        public string PlaceOfPermanentResidence { get; set; }
        [DisplayName("SĐT")]
        public string? PhoneNumber { get; set; }
        [DisplayName("Tỉnh nhập ngũ")]
        public string? ProvinceOfEnlistment { get; set; }
        [DisplayName("Văn hóa")]
        public string? EducationalLevel { get; set; }
        [DisplayName("Địa chỉ báo tin")]
        public string? AddressForCorrespondence { get; set; }
        [DisplayName("Sức khỏe")]
        public string? HealthStatus { get; set; }
        [DisplayName("Cấp bậc")]
        public string? MilitaryRank { get; set; }
        [DisplayName("Nhập ngũ")]
        public DateTime EnlistmentDate { get; set; }
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
        [DisplayName("Ngày tạo")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        [DisplayName("Ngày cập nhật")]
        public DateTime? ModifiedDate { get; set; }
        [DisplayName("Đang hoạt động")]
        public bool IsActive { get; set; } = true;
    }
}
