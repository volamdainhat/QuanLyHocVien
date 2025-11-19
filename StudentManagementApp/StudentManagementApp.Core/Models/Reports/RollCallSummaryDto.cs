using System.ComponentModel;

namespace StudentManagementApp.Core.Models.Reports
{
    public class RollCallSummaryDto
    {
        [DisplayName("Thời gian")]
        public DateTime Period { get; set; }
        [DisplayName("Tổng số buổi")]
        public int TotalSessions { get; set; }
        [DisplayName("Tỉ lệ điểm danh")]
        public double AverageAttendanceRate { get; set; }
        [DisplayName("Số vắng cao nhất")]
        public int MaxAbsent { get; set; }
    }

}
