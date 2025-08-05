using QuanLyHocVien.Domain.Entities;

namespace QuanLyHocVien.Infrastructure.Repositories.MisconductRepo
{
    public class MisconductRepository : Repository<Misconduct>
    {
        public MisconductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
