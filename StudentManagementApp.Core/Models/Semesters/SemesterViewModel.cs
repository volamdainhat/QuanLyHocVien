using System.ComponentModel;

namespace StudentManagementApp.Core.Models.Semesters
{
    public class SemesterViewModel : BaseViewModel
    {
        [DisplayName("Niên khóa")]
        public string? SchoolYearName { get; set; }
        [DisplayName("Học kỳ")]
        public required string Name { get; set; } // Ví dụ : I, II, III
        [DisplayName("Bắt đầu")]
        public required DateTime StartDate { get; set; }
        [DisplayName("Kết thúc")]
        public required DateTime EndDate { get; set; }
    }
}
