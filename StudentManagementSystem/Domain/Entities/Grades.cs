namespace StudentManagementSystem.Domain.Entities
{
    public class Grades
    {
        public int Id { get; set; }
        public int TraineeId { get; set; }
        public int SubjectId { get; set; }
        public required string Type { get; set; }
        public float Grade { get; set; }
    }
}
