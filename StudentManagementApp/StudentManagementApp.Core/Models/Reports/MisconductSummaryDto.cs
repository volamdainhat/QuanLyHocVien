using System.ComponentModel;

namespace StudentManagementApp.Core.Models.Reports
{
    public class MisconductSummaryDto
    {
        [DisplayName("Loại vị phạm")]
        public string Type { get; set; }
        [DisplayName("Số lượng")]
        public int Count { get; set; }
        [DisplayName("Thời gian")]
        public DateTime Period { get; set; }
    }

}
