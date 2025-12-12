using System.ComponentModel;

namespace StudentManagementApp.Core.Models.Classes
{
    public class ClassViewModel
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("Lớp học")]
        public string? Name { get; set; }
        //[DisplayName("Niên khóa")]
        //public string? SchoolYearName { get; set; }
        [DisplayName("Tổng học viên")]
        public int TotalStudents { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Ngày cập nhật")]
        public DateTime? ModifiedDate { get; set; }
        [DisplayName("Đang hoạt động")]
        public bool IsActive { get; set; } = true;
    }
}
