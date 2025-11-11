namespace StudentManagementApp.Core.Models.Reports
{
    /// <summary>
    /// DTO cho báo cáo theo thời gian
    /// </summary>
    public class TimeReportDto
    {
        public DateTime Date { get; set; }
        public string TimePeriod { get; set; } = string.Empty; // "Ngày", "Tuần", "Tháng"
        public int TotalTrainees { get; set; }
        public int PresentCount { get; set; }
        public int AbsentCount { get; set; }
        public decimal AttendanceRate { get; set; }
        public int MisconductCount { get; set; }
        public decimal AveragePracticePoint { get; set; }
        public string? Notes { get; set; }
    }
}
