using System.ComponentModel;

namespace StudentManagementApp.Core.Models.TraineeAverageScores
{
    public class TraineeAverageScoreSummaryModel
    {
        [DisplayName("Xếp loại")]
        public string? GradeType { get; set; }
        [DisplayName("Tổng")]
        public int Summary { get; set; }
    }
}
