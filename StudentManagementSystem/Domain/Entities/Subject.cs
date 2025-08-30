namespace StudentManagementSystem.Domain.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        // Navigation: schedules using this subject
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
