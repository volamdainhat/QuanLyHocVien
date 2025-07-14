using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Domain.Entities
{
    public class Misconduct
    {
        public int misconductId { get; set; }
        public int studentId { get; set; }
        public int misconductType { get; set; }
        public DateTime dateTime { get; set; }
        public string Description { get; set; }
    }
}
