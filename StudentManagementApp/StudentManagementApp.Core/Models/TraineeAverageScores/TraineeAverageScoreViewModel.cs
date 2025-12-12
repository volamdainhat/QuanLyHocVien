using System.ComponentModel;

namespace StudentManagementApp.Core.Models.TraineeAverageScores
{
    public class TraineeAverageScoreViewModel : BaseViewModel
    {
        [DisplayName("Học viên")]
        public string? TraineeName { get; set; }
        [DisplayName("Lớp")]
        public string? ClassName { get; set; }
        //[DisplayName("Học kỳ")]
        //public string? SemesterName { get; set; }
        [DisplayName("Điểm TB")]
        public decimal AverageScore { get; set; }
        [DisplayName("Xếp loại")]
        public string? GradeType { get; set; }
    }
}
