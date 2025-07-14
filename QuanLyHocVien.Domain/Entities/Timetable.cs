using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Domain.Entities
{
    public class Timetable
    {
        public int TimetableId { get; set; }
        public int ClassId { get; set; }
        public string Subject { get; set; }
        public string RoomNumber { get; set; }
    }
}
