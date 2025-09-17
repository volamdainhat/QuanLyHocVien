using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementApp.Core.Entities
{
    [Table("Trainees")]
    public class Trainee : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public required string FullName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DayOfBirth { get; set; }
        [Required]
        public required bool Gender { get; set; }
        [Required]
        public required string IdentityCard { get; set; }
        [Required]
        public required string Ethnicity { get; set; }
        [Required]
        public required string PlaceOfOrigin { get; set; }
        [Required]
        public required string PlaceOfPermanentResidence { get; set; }
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
        [Required]
        public required string ProvinceOfEnlistment { get; set; }
        [Required]
        public required string EducationalLevel { get; set; }
        [Required]
        public required string AddressForCorrespondence { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public required DateTime EnlistmentDate { get; set; }
        [Required]
        public required string MilitaryRank { get; set; }
        [Required]
        public required string HealthStatus { get; set; }
        [Required]
        [MaxLength(50)]
        public string? Role { get; set; }
        [Range(0.0, 10.0)]
        public decimal AverageScore { get; set; }
        [MaxLength(255)]
        public string? FatherFullName { get; set; }
        [MaxLength(20)]
        public string? FatherPhoneNumber { get; set; }
        [MaxLength(255)]
        public string? MotherFullName { get; set; }
        [MaxLength(20)]
        public string? MotherPhoneNumber { get; set; }
        [MaxLength(500)]
        public string? AvatarUrl { get; set; }
        [Range(0, 60)]
        public int MeritScore { get; set; }
        [ForeignKey("Class")]
        public int ClassId { get; set; }
        // Navigation property
        public virtual Class? Class { get; set; }
    }
}
