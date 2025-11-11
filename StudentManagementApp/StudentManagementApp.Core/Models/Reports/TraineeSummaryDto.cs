namespace StudentManagementApp.Core.Models.Reports
{
    /// <summary>
    /// DTO cho tổng hợp học viên
    /// </summary>
    public class TraineeSummaryDto
    {
        public int TraineeId { get; set; }
        public string TraineeName { get; set; } = string.Empty;
        public int TotalDays { get; set; }
        public int PresentDays { get; set; }
        public decimal AttendanceRate { get; set; }
        public int TotalMisconducts { get; set; }
        public decimal AveragePracticePoint { get; set; }
        public string MostCommonMisconduct { get; set; } = string.Empty;
        public string Rating { get; set; } = string.Empty;
    }
}
