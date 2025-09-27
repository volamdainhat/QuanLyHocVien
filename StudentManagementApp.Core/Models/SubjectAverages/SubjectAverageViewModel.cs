using System.ComponentModel;

namespace StudentManagementApp.Core.Models.Trainees
{
    public class SubjectAverageViewModel : BaseViewModel
    {
        [DisplayName("Môn học")]
        public string? SubjectName { get; set; }
        [DisplayName("Học viên")]
        public string? TraineeName { get; set; }
        [DisplayName("Điểm TB môn")]
        public decimal Score { get; set; }
        [DisplayName("Xếp loại")]
        public string? GradeType { get; set; }
    }
}
