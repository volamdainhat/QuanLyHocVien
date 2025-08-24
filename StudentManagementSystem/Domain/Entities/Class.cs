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

    // Navigation property
    public ICollection<Trainee> Trainees { get; set; } = new List<Trainee>();

    // Computed property, not stored in DB
    [NotMapped]
    public int TotalStudents => Trainees?.Count ?? 0;
}