using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementApp.Core.Entities
{
    [Table("Categories")]
    public class Category : BaseEntity
    {
        [Required]
        public int ParentId { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Type { get; set; }
        [Required]
        [MaxLength(50)]
        public required string Code { get; set; }
        [Required]
        [MaxLength(255)]
        public required string Name { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        public int SortOrder { get; set; }
    }
}
