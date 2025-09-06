namespace StudentManagementSystem.Applications.DTOs
{
    public class SubjectAverageScoreView
    {
        public int Id { get; set; }
        //public string TraineeName { get; set; } = "";
        public string SubjectName { get; set; } = "";
        public decimal AverageScore { get; set; }
        public string? Grade { get; set; }
        public string? Semester { get; set; }
        public string? SchoolYear { get; set; }
    }
}
