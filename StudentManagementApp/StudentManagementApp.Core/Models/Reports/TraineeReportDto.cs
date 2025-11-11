namespace StudentManagementApp.Core.Models.Reports
{
    /// <summary>
    /// Dto cho báo cáo học viên
    /// </summary>
    public class TraineeReportDto
    {
        public int TraineeId { get; set; }
        public string TraineeName { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string? AttendanceStatus { get; set; } // "Có mặt", "Vắng"
        public int MisconductCount { get; set; }
        public string? MisconductTypes { get; set; }
        public decimal? PracticePoint { get; set; }
        public string? PracticeContent { get; set; }
        public string? Notes { get; set; }
    }
}
