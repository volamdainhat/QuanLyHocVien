using System.ComponentModel;

namespace QuanLyHocVien.Applications.DTOs
{
    public class ClassDto
    {
        public class ViewModel
        {
            [Browsable(false)]
            public int Id { get; set; }

            [DisplayName("Tên lớp")]
            public required string Name { get; set; }

            [DisplayName("Ngày mở lớp")]
            public DateTime StartDate { get; set; }

            [DisplayName("Ngày đóng lớp")]
            public DateTime EndDate { get; set; }

            [DisplayName("Tổng số học sinh")]
            public int TotalStudents { get; set; }
        }
    }
}
