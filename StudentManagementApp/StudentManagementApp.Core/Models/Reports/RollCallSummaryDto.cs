namespace StudentManagementApp.Core.Models.Reports
{
    public class RollCallSummaryDto
    {
        public DateTime Period { get; set; }
        public int TotalSessions { get; set; }
        public double AverageAttendanceRate { get; set; }
        public int MaxAbsent { get; set; }
    }

}
