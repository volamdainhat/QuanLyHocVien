using QuanLyHocVien.Domain.Entities;

namespace QuanLyHocVien.Infrastructure.Repositories.SubjectRepo
{
    public class SubjectRepository : Repository<Subject>
    {
        public SubjectRepository(AppDbContext context) : base(context)
        {
        }
    }
}
