using Microsoft.EntityFrameworkCore;
using QuanLyHocVien.Domain.Entities;

namespace QuanLyHocVien.Infrastructure.Repositories.GradesRepo
{
    public class GradesRepository : Repository<Grades>, IGradesRepository
    {
        public GradesRepository(AppDbContext context) : base(context) { }
    }
}
