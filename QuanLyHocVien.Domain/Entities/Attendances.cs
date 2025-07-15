using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Domain.Entities
{
    public class Attendances
    {
        /// <summary>
        /// Identifier for the class.
        /// </summary>
        public int ClassId { get; set; }

        /// <summary>
        /// Timetable of the class.
        /// </summary>
        public int TimetableId { get; set; }

        /// <summary>
        /// Identifier for the trainee.
        /// </summary>
        public int TraineeId { get; set; }

        /// <summary>
        /// Attendance date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Attendance status type.
        /// </summary>
        public required string Type { get; set; }

        /// <summary>
        /// Reason for the attendance status.
        /// </summary>
        public string? Reason { get; set; }
    }
}
