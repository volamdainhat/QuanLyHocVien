using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementApp.Core.Entities
{
    [Index(nameof(Code), IsUnique = true)]
    [Table("Subjects")]
    public class Subject : BaseEntity
    {
        [Required]
        [MaxLength(20)]
        public required string Code { get; set; }
        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }
        [Required]
        public required int Coefficient { get; set; }
    }
}
