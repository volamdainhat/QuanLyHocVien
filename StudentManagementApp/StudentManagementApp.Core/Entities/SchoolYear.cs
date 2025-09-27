using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagementApp.Core.Entities
{
    [Table("SchoolYears")]
    public class SchoolYear : BaseEntity
    {
        [Required]
        [MaxLength(255)]
        public required string Name { get; set; } // Ví dụ: "2023-2024"
        [Required]
        [DataType(DataType.Date)]
        public required DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public required DateTime EndDate { get; set; }

        // Navigation property
        public virtual ICollection<Class>? Classes { get; set; }

        public SchoolYear()
        {
            Name = string.Empty;
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
        }
    }

    // Class để validate ngày kết thúc phải sau ngày bắt đầu
    public class SchoolYearAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var schoolYear = (SchoolYear)validationContext.ObjectInstance;

            if (schoolYear.EndDate <= schoolYear.StartDate)
            {
                return new ValidationResult("Ngày kết thúc phải sau ngày bắt đầu");
            }

            return ValidationResult.Success;
        }
    }
}
