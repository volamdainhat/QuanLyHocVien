using System.ComponentModel;

namespace StudentManagementApp.Core.Models.Reports
{
    public class RollCallDetailDto
    {
        [Browsable(false)]
        public int Id { get; set; }
        [DisplayName("Ngày")]
        public DateTime Date { get; set; }
        [DisplayName("Người điểm danh")]
        public string RollCaller { get; set; }
        [DisplayName("Tổng số")]
        public int TotalStudents { get; set; }
        [DisplayName("Có mặt")]
        public int Present { get; set; }
        [DisplayName("Tỷ lệ")]
        public string Percentage { get; set; }
        [DisplayName("Vắng mặt")]
        public int Absent { get; set; }
        [DisplayName("Ghi chú")]
        public string Notes { get; set; }
    }

}
