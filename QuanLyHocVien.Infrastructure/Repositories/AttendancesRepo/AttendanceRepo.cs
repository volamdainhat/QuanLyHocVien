using Microsoft.EntityFrameworkCore;
using QuanLyHocVien.Domain.Entities;

namespace QuanLyHocVien.Infrastructure.Repositories.AttendancesRepo
{
    public class AttendanceRepository : Repository<Attendances>, IAttendanceRepository
    {
        public AttendanceRepository(AppDbContext context) : base(context) { }


    }
}
