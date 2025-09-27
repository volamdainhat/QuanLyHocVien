using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementApp.Core.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        [MaxLength(50)]
        public string? Category { get; set; }
    }
}
