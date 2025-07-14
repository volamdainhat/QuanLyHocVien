using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Domain.Entities
{
    public class Grades
    {
        public int StudentId { get; set; }
        public int GradeForSubject { get; set; }
        public string GradeType { get; set; }
        public float grade { get; set; }
    }
}
