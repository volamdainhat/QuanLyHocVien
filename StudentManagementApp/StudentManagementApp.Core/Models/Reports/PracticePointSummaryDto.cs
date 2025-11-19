using System.ComponentModel;

namespace StudentManagementApp.Core.Models.Reports
{
    public class PracticePointSummaryDto
    {
        [DisplayName("Nội dung")]
        public string Content { get; set; }
        [DisplayName("Tổng điểm")]
        public decimal TotalPoints { get; set; }
        [DisplayName("Thời gian")]
        public DateTime Period { get; set; }
    }
}
