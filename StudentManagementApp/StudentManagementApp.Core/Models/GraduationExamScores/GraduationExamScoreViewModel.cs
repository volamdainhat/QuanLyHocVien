using System.ComponentModel;

namespace StudentManagementApp.Core.Models.GraduationExamScores
{
    public class GraduationExamScoreViewModel : BaseViewModel
    {
        [Browsable(false)]
        public int ClassId { get; set; }
        [DisplayName("Học viên")]
        public string? TraineeName { get; set; }
        [DisplayName("Lớp")]
        public string? ClassName { get; set; }
        [Browsable(false)]
        [DisplayName("Môn thi")]
        public string? GraduationExamType { get; set; }
        [DisplayName("Môn thi")]
        public string? GraduationExamTypeName { get; set; }
        [DisplayName("Điểm thi")]
        public decimal Score { get; set; }
        [DisplayName("Xếp loại")]
        public string? GradeType { get; set; }
    }
}
