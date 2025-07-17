namespace QuanLyHocVien.Domain.Entities
{
    /// <summary>
    /// Represents a class with details such as its identifier, name, schedule, and student count.
    /// </summary>
    /// <remarks>This class provides properties to store information about a class, including its unique
    /// identifier, name, start and end dates, and the total number of students enrolled. It can be used to model
    /// educational or training sessions in applications that manage class schedules or student data.</remarks>
    public class Class
    {
        /// <summary>
        /// Identifier for the class.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Class name.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Start date of the class.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date of the class.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Total number of students in the class.
        /// </summary>
        public int TotalStudents { get; set; }
    }
}
