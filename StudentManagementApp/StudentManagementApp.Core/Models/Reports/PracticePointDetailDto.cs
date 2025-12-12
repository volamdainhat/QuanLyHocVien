using System.ComponentModel;

namespace StudentManagementApp.Core.Models.Reports
{
    public class PracticePointDetailDto
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("Học viên")]
        public string TraineeName { get; set; }
        [DisplayName("Lớp học")]
        public string ClassName { get; set; }
        [DisplayName("Nội dung")]
        public string Content { get; set; }
        [DisplayName("Điểm")]
        public decimal Point { get; set; }
        [DisplayName("Thời gian")]
        public DateTime Time { get; set; }
        [DisplayName("Mô tả")]
        public string Description { get; set; }
    }

}
