using System.ComponentModel;

namespace StudentManagementApp.Core.Models.RollCalls
{
    public class RollCallViewModel : BaseViewModel
    {
        [DisplayName("Ngày")]
        public DateTime Date { get; set; }
        [DisplayName("Lớp")]
        public string? ClassName { get; set; }
        [DisplayName("Người điểm danh")]
        public string? RollCaller { get; set; }
        [DisplayName("Số lượng")]
        public int TotalStudents { get; set; }
        [DisplayName("Có mặt")]
        public int Present { get; set; }
        [DisplayName("Vắng mặt")]
        public int Absent { get; set; }
        [DisplayName("Ghi chú")]
        public string? Notes { get; set; }
    }
}
