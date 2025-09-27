using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementApp.Core.Models.Grades
{
    public class GradesViewModel
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("Học viên")]
        public string? TraineeName { get; set; }
        [DisplayName("Môn học")]
        public string? SubjectName { get; set; }
        [DisplayName("Học kỳ")]
        public string? SemesterName { get; set; }
        [DisplayName("Loại thi")]
        public string? ExamType { get; set; }
        [DisplayName("Điểm số")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải nằm trong khoảng từ 0 đến 10")]
        public decimal Grade { get; set; }
        [DisplayName("Xếp loại")]
        public string? GradeType { get; set; }
        [DisplayName("Ngày tạo")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Ngày cập nhật")]
        public DateTime? ModifiedDate { get; set; }
        [DisplayName("Đang hoạt động")]
        public bool IsActive { get; set; } = true;
    }
}
