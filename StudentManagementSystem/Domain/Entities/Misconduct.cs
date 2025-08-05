namespace StudentManagementSystem.Domain.Entities
{
    public class Misconduct
    {
        public int Id { get; set; }
        public int TraineeId { get; set; }
        public required string Type { get; set; }
        public DateTime Time { get; set; }
        public string? Description { get; set; }
    }
}
