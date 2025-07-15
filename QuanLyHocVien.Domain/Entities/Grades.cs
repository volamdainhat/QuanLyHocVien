using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Domain.Entities
{
    public class Grades
    {
        public int TraineeId { get; set; }
        public int SubjectId { get; set; }
        public required string Type { get; set; }
        public float Grade { get; set; }
    }
}
