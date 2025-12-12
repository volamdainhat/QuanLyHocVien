using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementApp.Core.Entities
{
    [Index(nameof(Name))]
    [Table("Classes")]
    public class Class : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }
        //public int SchoolYear { get; set; }
        public int TotalStudents { get; set; }
    }
}
