using QuanLyHocVien.Domain.Entities;

namespace QuanLyHocVien.Infrastructure.Repositories.ReportRepo
{
    public class ReportRepository : Repository<Reports>, IReportRepository
    {
        public ReportRepository(AppDbContext context) : base(context) { }
    }
}
