using System.ComponentModel;

namespace StudentManagementApp.Core.Models.Reports
{
    public class RollCallSummaryDto
    {
        [DisplayName("Từ ngày")]
        public DateTime FromDate { get; set; }
        [DisplayName("Đến ngày")]
        public DateTime ToDate { get; set; }
        [DisplayName("Lớp")]
        public string? ClassName { get; set; }
        [DisplayName("Tổng số buổi")]
        public int TotalSessions { get; set; }
        [DisplayName("Tỉ lệ điểm danh")]
        public double AverageAttendanceRate { get; set; }
        [DisplayName("Số vắng cao nhất")]
        public int MaxAbsent { get; set; }
    }

}
