using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Domain.Entities
{
    internal class User
    {
        public int UserId { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
