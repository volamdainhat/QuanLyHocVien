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
                .Include(c => c.SchoolYear)
                .Select(c => new ClassViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    SchoolYearName = c.SchoolYear != null ? c.SchoolYear.Name : "",
                    TotalStudents = c.TotalStudents,
                    CreatedDate = c.CreatedDate,
                    ModifiedDate = c.ModifiedDate
                })
                .ToListAsync();
        }

        public async Task<Class> GetClassWithDetailsAsync(int id)
        {
            return await _context.Classes
                .Include(c => c.SchoolYear)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
