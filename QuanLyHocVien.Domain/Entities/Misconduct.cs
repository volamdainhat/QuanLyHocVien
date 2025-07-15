using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Domain.Entities
{
    public class Misconduct
    {
        public int Id { get; set; }
        public int TraineeId { get; set; }
        public required string Type { get; set; }
        public DateTime Time { get; set; }
        public string? Description { get; set; }
    }
}
