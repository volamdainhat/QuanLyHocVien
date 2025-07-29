using System.ComponentModel;

namespace QuanLyHocVien.Domain.Entities
{
    /// <summary>
    /// Represents a trainee in the system, including personal details, class information, and parental contact data.
    /// </summary>
    /// <remarks>The <see cref="Trainee"/> class provides properties to store information about a trainee,
    /// such as their name, class ID, ranking, and enlistment date. It also includes optional fields for parental
    /// contact information and average score. This class is typically used to manage trainee records in educational or
    /// training systems.</remarks>
    public class Trainee
    {
        /// <summary>
        /// Identifier for the trainee.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the trainee.
        /// </summary>
        public required string FullName { get; set; }

        /// <summary>
        /// Class identifier that the trainee belongs to.
        /// </summary>
        public required int ClassId { get; set; }

        /// <summary>
        /// Phone number of parent or guardian.
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        public DateTime? DayOfBirth { get; set; }

        /// <summary>
        /// Ranking of the trainee in the class.
        /// </summary>
        public required string Ranking { get; set; }

        /// <summary>
        /// Date of enlistment of the trainee
        /// </summary>
        public required DateTime EnlistmentDate { get; set; }

        /// <summary>
        /// Average score of the trainee.
        /// </summary>
        public float? AverageScore { get; set; }

        /// <summary>
        /// Role of the trainee in the system.
        /// </summary>
        public required string Role { get; set; } = "Học viên";

        /// <summary>
        /// Father's full name of the trainee.
        /// </summary>
        public string? FatherFullName { get; set; }

        /// <summary>
        /// Phone number of the trainee's father.
        /// </summary>
        public string? FatherPhoneNumber { get; set; }

        /// <summary>
        /// Mother's full name of the trainee.
        /// </summary>
        public string? MotherFullName { get; set; }

        /// <summary>
        /// Phone number of the trainee's mother.
        /// </summary>
        public string? MotherPhoneNumber { get; set; }
    }
}
