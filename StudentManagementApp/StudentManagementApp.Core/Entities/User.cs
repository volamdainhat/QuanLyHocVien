using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementApp.Core.Entities
{
    [Index(nameof(Username), nameof(Email), IsUnique = true)]
    [Table("Users")]
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public required string Username { get; set; }
        [Required]
        public required string PasswordHash { get; set; }
        [Required]
        [MaxLength(100)]
        public required string Email { get; set; }
        [Required]
        [MaxLength(100)]
        public required string FullName { get; set; }
        [MaxLength(20)]
        public string Role { get; set; } = "User"; // Admin, User, etc.
        public DateTime? LastLoginDate { get; set; }
    }
}