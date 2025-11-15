namespace StudentManagementApp.Core.Models.Reports
{
    public class RollCallDetailDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string RollCaller { get; set; }
        public int TotalStudents { get; set; }
        public int Present { get; set; }
        public int Absent { get; set; }
        public string Notes { get; set; }
    }

}
