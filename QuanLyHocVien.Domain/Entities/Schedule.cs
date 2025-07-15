using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Domain.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Schedule
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public int SubjectId { get; set; }
        public required string Room { get; set; }
        public required string Period { get; set; }
        public required DateTime Day { get; set; }
    }
}
