using QuanLyHocVien.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Infrastructure.Repositories.MisconductRepo
{
    public class MisconductRepository: Repository<Misconduct>, IMisconductRepository
    {
        public MisconductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
