using System.ComponentModel.DataAnnotations.Schema;
using StudentManagementSystem.Domain.Entities;

namespace StudentManagementSystem.Domain.Entities;
public class Class
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int MaxStudents { get; set; }

    // Navigation: students
    public ICollection<Trainee> Trainees { get; set; } = new List<Trainee>();

    // Navigation: schedules
    public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    // Computed property, not stored in DB
    [NotMapped]
    public int TotalStudents => Trainees?.Count ?? 0;
}