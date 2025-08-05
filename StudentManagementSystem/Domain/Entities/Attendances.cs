namespace StudentManagementSystem.Domain.Entities
{
    public class Attendances
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int TimetableId { get; set; }
        public int TraineeId { get; set; }
        public DateTime Date { get; set; }
        public required string Type { get; set; }
        public string? Reason { get; set; }
    }
}
