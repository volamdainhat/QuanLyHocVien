using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Domain.Entities
{
    public class Trainee
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int ClassID { get; set; }
        public string Phonenumber { get; set; }
        public DateTime DayOfBirth { get; set; }
        public string Ranking { get; set; }
        public DateTime EnlistmentDate { get; set; }
        public float AverageScore { get; set; }
        public string Role { get; set; } = "Hoc vien";
        public string ParentFullnames { get; set; }
        public List<string> ParentNumbers { get; set; }
    }
}
