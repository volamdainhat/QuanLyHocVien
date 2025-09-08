namespace StudentManagementSystem.Domain.Entities
{
    public class Reports
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; } = null!;

        public int MisconductCount { get; set; }
        public int TotalStudents { get; set; }
        public int TotalAbsences { get; set; }
        public float AverageScore { get; set; }

        // When this report was generated
        public DateTime ReportDate { get; set; }

        // 🔑 Anchors for the data range
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
