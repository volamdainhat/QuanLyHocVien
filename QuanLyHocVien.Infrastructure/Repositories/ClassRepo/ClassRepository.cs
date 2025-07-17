using Microsoft.EntityFrameworkCore;
using QuanLyHocVien.Domain.Entities;

namespace QuanLyHocVien.Infrastructure.Repositories.ClassRepo
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        public ClassRepository(AppDbContext context) : base(context) { }

        
    }
}
