using QuanLyHocVien.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyHocVien.Infrastructure.Repositories.ReportRepo
{
    public class ReportRepository : Repository<Reports>, IReportRepository
    {
        public ReportRepository(AppDbContext context) : base(context) {}
    }
}
