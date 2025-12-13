using System.ComponentModel;

namespace StudentManagementApp.Core.Models.Trainees
{
    public class SubjectAverageViewModel : BaseViewModel
    {
        [Browsable(false)]
        public int SubjectId { get; set; }
        [Browsable(false)]
        public int ClassId { get; set; }
        [DisplayName("Môn học")]
        public string? SubjectName { get; set; }
        [DisplayName("Học viên")]
        public string? TraineeName { get; set; }
        [DisplayName("Lớp")]
        public string? ClassName { get; set; }
        [DisplayName("Điểm TB môn")]
        public decimal Score { get; set; }
        [DisplayName("Xếp loại")]
        public string? GradeType { get; set; }
    }
}
