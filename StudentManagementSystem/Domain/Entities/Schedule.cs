using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementSystem.Domain.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public string Room { get; set; }
        public string Period { get; set; }

        // actual calendar date (generated between start and end dates)
        public DateTime Date { get; set; }
    }
}
