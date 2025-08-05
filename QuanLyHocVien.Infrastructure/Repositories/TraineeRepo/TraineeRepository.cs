using Microsoft.EntityFrameworkCore;
using QuanLyHocVien.Domain.Entities;

namespace QuanLyHocVien.Infrastructure.Repositories.TraineeRepo
{
    public class TraineeRepository : Repository<Trainee>
    {
        public TraineeRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Trainee>> SearchAsync(string keyword, int classId)
        {
            var query = context.Trainees.AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
                query = query.Where(h => h.FullName.Contains(keyword));

            if (classId > 0)
                query = query.Where(h => h.ClassId == classId);

            return await query.ToListAsync();
        }
    }
}
