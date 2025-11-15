namespace StudentManagementApp.Core.Models.Reports
{
    public class PracticePointDetailDto
    {
        public int Id { get; set; }
        public string TraineeName { get; set; }
        public string Content { get; set; }
        public decimal Point { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
    }

}
