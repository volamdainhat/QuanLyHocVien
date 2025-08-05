using QuanLyHocVien.Domain.Entities;

namespace QuanLyHocVien.Infrastructure.Repositories.ReportRepo
{
    public class ReportRepository : Repository<Reports>
    {
        public ReportRepository(AppDbContext context) : base(context) { }
    }
}
