using System.ComponentModel;

namespace StudentManagementApp.Core.Models.PracticePoints
{
    public class PracticePointViewModel : BaseViewModel
    {
        [DisplayName("Học viên")]
        public string? TraineeName { get; set; }
        [DisplayName("Lớp")]
        public string? ClassName { get; set; }
        [DisplayName("Nội dung")]
        public string? Content { get; set; }
        [DisplayName("Điểm cộng")]
        public decimal Point { get; set; }
        [DisplayName("Thời điểm")]
        public DateTime Time { get; set; }
        [DisplayName("Mô tả")]
        public string? Description { get; set; }
    }
}
