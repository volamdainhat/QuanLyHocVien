using System.ComponentModel;

namespace StudentManagementApp.Core.Models.TraineeAverageScores
{
    public class TraineeAverageScoreViewModel : BaseViewModel
    {
        [Browsable(false)]
        public int ClassId { get; set; }
        [DisplayName("Học viên")]
        public string? TraineeName { get; set; }
        [DisplayName("Lớp")]
        public string? ClassName { get; set; }
        [DisplayName("Điểm TB")]
        public decimal AverageScore { get; set; }
        [DisplayName("Xếp loại")]
        public string? GradeType { get; set; }
    }
}
