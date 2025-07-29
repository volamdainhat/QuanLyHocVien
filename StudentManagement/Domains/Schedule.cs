namespace QuanLyHocVien.Domain.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int SubjectId { get; set; }
        public required string Room { get; set; }
        public required string Period { get; set; }
        public required DateTime Day { get; set; }
    }
}
