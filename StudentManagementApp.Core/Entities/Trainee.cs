using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementApp.Core.Entities
{
    internal class Trainee : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public required string FullName { get; set; }
        [ForeignKey("Class")]
        public int ClassId { get; set; }
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DayOfBirth { get; set; }
        public string? MilitaryRank { get; set; }
        public DateTime? EnlistmentDate { get; set; }
        public decimal? AverageScore { get; set; }
        public string? Role { get; set; }
        public string? FatherFullName { get; set; }
        public string? FatherPhoneNumber { get; set; }
        public string? MotherFullName { get; set; }
        public string? MotherPhoneNumber { get; set; }
        public string? AvatarUrl { get; set; }
        public int MeritScore { get; set; } = 30;

        // Navigation property
        public virtual Class? Class { get; set; }
    }
}
