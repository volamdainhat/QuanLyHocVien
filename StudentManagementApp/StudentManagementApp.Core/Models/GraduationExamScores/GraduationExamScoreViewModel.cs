using System.ComponentModel;

namespace StudentManagementApp.Core.Models.GraduationExamScores
{
    public class GraduationExamScoreViewModel : BaseViewModel
    {
        [DisplayName("Học viên")]
        public string? TraineeName { get; set; }
        [DisplayName("Môn thi")]
        public string? GraduationExamType { get; set; }
        [DisplayName("Điểm thi")]
        public decimal Score { get; set; }
        [DisplayName("Xếp loại")]
        public string? GradeType { get; set; }
    }
}
