namespace QuanLyHocVien.Domain.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalStudents { get; set; }
    }
}
