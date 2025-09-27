using System.ComponentModel;

namespace StudentManagementApp.Core.Models.Schedules
{
    public class ScheduleViewModel : BaseViewModel
    {
        [DisplayName("Lớp học")]
        public string? ClassName { get; set; }
        [DisplayName("Môn học")]
        public string? SubjectId { get; set; }
        [DisplayName("Phòng học")]
        public string? Room { get; set; }
        [DisplayName("Buổi học")]
        public string? Period { get; set; }
        [DisplayName("Ngày học")]
        public DateTime Date { get; set; }
    }
}
