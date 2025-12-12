using System.ComponentModel;

namespace StudentManagementApp.Core.Models.GraduationScores
{
    public class GraduationScoreViewModel : BaseViewModel
    {
        [DisplayName("Học viên")]
        public string? TraineeName { get; set; }
        [DisplayName("Lớp")]
        public string? ClassName { get; set; }
        [DisplayName("Điểm xét tốt nghiệp")]
        public decimal Score { get; set; }
        [DisplayName("Xếp loại tốt nghiệp")]
        public string? GraduationType { get; set; }
    }
}
