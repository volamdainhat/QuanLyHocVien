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
        [Browsable(false)]
        public int Id { get; set; }

        /// <summary>
        /// Name of the trainee.
        /// </summary>
        [DisplayName("Họ và tên")]
        public required string FullName { get; set; }

        /// <summary>
        /// Class identifier that the trainee belongs to.
        /// </summary>
        [DisplayName("Mã lớp")]
        public required int ClassId { get; set; }

        /// <summary>
        /// Phone number of parent or guardian.
        /// </summary>
        [DisplayName("Số điện thoại")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        [DisplayName("Ngày sinh")]
        public DateTime? DayOfBirth { get; set; }

        /// <summary>
        /// Ranking of the trainee in the class.
        /// </summary>
        [DisplayName("Cấp bậc")]
        public required string Ranking { get; set; }

        /// <summary>
        /// Date of enlistment of the trainee
        /// </summary>
        [DisplayName("Ngày nhập ngũ")]
        public required DateTime EnlistmentDate { get; set; }

        /// <summary>
        /// Average score of the trainee.
        /// </summary>
        [DisplayName("Điêm trung bình")]
        public float? AverageScore { get; set; }

        /// <summary>
        /// Role of the trainee in the system.
        /// </summary>
        [DisplayName("Vai trò")]
        public required string Role { get; set; } = "Học viên";

        /// <summary>
        /// Father's full name of the trainee.
        /// </summary>
        [DisplayName("Họ tên cha")]
        public string? FatherFullName { get; set; }

        /// <summary>
        /// Phone number of the trainee's father.
        /// </summary>
        [DisplayName("Số điện thoại cha")]
        public string? FatherPhoneNumber { get; set; }

        /// <summary>
        /// Mother's full name of the trainee.
        /// </summary>
        [DisplayName("Họ tên mẹ")]
        public string? MotherFullName { get; set; }

        /// <summary>
        /// Phone number of the trainee's mother.
        /// </summary>
        [DisplayName("Số điẹnt thoại mẹ")]
        public string? MotherPhoneNumber { get; set; }
    }
}
