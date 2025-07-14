using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int TotalTrainees { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
