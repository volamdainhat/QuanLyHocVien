using System.ComponentModel;

namespace StudentManagementApp.Core.Models.Reports
{
    public class MisconductDetailDto
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("Học viên")]
        public string TraineeName { get; set; }
        [DisplayName("Loại vi phạm")]
        public string Type { get; set; }
        [DisplayName("Thời gian")]
        public DateTime Time { get; set; }
        [DisplayName("Mô tả")]
        public string Description { get; set; }
    }

}
