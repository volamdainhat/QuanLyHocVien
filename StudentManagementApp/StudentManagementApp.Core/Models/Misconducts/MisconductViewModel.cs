using System.ComponentModel;

namespace StudentManagementApp.Core.Models.Misconducts
{
    public class MisconductViewModel : BaseViewModel
    {
        [Browsable(false)]
        public int ClassId { get; set; }
        [DisplayName("Học viên")]
        public string? TraineeName { get; set; }
        [DisplayName("Lớp")]
        public string? ClassName { get; set; }
        [DisplayName("Vi phạm")]
        public string? Type { get; set; }
        [DisplayName("Thời điểm")]
        public DateTime Time { get; set; }
        [DisplayName("Mô tả")]
        public string? Description { get; set; }
    }
}
