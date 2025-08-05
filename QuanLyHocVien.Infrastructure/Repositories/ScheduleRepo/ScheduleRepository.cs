using QuanLyHocVien.Domain.Entities;

namespace QuanLyHocVien.Infrastructure.Repositories.ScheduleRepo
{
    public class ScheduleRepository : Repository<Schedule>
    {
        public ScheduleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
