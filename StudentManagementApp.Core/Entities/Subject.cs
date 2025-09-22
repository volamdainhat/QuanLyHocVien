using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementApp.Core.Entities
{
    [Table("Subjects")]
    public class Subject : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }
    }
}
