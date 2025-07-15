using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Domain.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
