using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Models.Classes;
using StudentManagementApp.Infrastructure.Data;

namespace StudentManagementApp.Infrastructure.Repositories
{
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        public ClassRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ClassViewModel>> GetClassesWithSchoolYearAsync()
        {
            return await _context.Classes
                .GroupJoin(_context.SchoolYears,
                    c => c.SchoolYear,
                    sy => sy.Id,
                    (c, schoolYears) => new { Class = c, SchoolYears = schoolYears })
                .SelectMany(
                    x => x.SchoolYears.DefaultIfEmpty(),
                    (c, sy) => new ClassViewModel
                    {
                        Id = c.Class.Id,
                        Name = c.Class.Name,
                        SchoolYearName = sy != null ? sy.Name : "", // Trả về rỗng nếu không có
                        TotalStudents = c.Class.TotalStudents,
                        CreatedDate = c.Class.CreatedDate,
                        ModifiedDate = c.Class.ModifiedDate
                    })
                .ToListAsync();
        }

        public async Task<Class> GetClassWithDetailsAsync(int id)
        {
            return await _context.Classes
                //.Include(c => c.SchoolYear)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
