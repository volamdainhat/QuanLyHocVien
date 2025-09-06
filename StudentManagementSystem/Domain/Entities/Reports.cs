namespace StudentManagementSystem.Domain.Entities
{
    public class Reports
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; } = null;
        public int MisconductCount { get; set; }
        public int TotalStudents { get; set; }
        public int TotalAbsences { get; set; } // Unsure about this one
        public float AverageScore { get; set; }
        public DateTime ReportDate { get; set; }
    }
}
