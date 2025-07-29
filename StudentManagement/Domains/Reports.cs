namespace QuanLyHocVien.Domain.Entities
{
    public class Reports
    {
        public int Id { get; set; }
        public int ReportId { get; set; }
        public int ClassId { get; set; }
        public int MisconductCount { get; set; }
        public int TotalStudents { get; set; }
        public int TotalAbsences { get; set; }
        public float AverageScore { get; set; }
        public DateTime ReportDate { get; set; }
    }
}
