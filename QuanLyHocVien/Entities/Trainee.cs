using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Entities
{
    public class Trainee
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public required Class Class { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Ranking { get; set; } = string.Empty;
        public string Role { get; set; } = "Học viên";
        public DateTime? EnlistmentDate { get; set; }
        public double AverageGrade { get; set; } = 0.0;
    }
}
