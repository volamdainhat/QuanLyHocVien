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
        [DataType(DataType.Date)]
        public DateTime DayOfBirth { get; set; }
        public bool Gender { get; set; }
        public string IdentityCard { get; set; }
        public string Ethnicity { get; set; }
        public string PlaceOfOrigin { get; set; }
        public string PlaceOfPermanentResidence { get; set; }
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }
        public string ProvinceOfEnlistment { get; set; }
        public string EducationalLevel { get; set; }
        public string AddressForCorrespondence { get; set; }
        [DataType(DataType.Date)]
        public DateTime EnlistmentDate { get; set; }
        public string MilitaryRank { get; set; }
        public string HealthStatus { get; set; }
        [MaxLength(50)]
        public string? Role { get; set; }
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
        [ForeignKey("Class")]
        public int? ClassId { get; set; }
        // Navigation property
        public virtual Class? Class { get; set; }
    }
}
