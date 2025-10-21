using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Models.Semesters;
using StudentManagementApp.Infrastructure.Data;

namespace StudentManagementApp.Infrastructure.Repositories
{
    public class SemesterRepository : Repository<Semester>, ISemesterRepository
    {
        public SemesterRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<SemesterViewModel>> GetSemestersWithSchoolYearAsync()
        {
            return await _context.Semesters
                .Include(c => c.SchoolYear)
                .Select(c => new SemesterViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    SchoolYearName = c.SchoolYear != null ? c.SchoolYear.Name : "",
                    StartDate = c.StartDate,
                    EndDate = c.EndDate,
                    IsActive = c.IsActive,
                    CreatedDate = c.CreatedDate,
                    ModifiedDate = c.ModifiedDate
                })
                .ToListAsync();
        }

        public async Task<Semester> GetSemesterWithDetailsAsync(int id)
        {
            return await _context.Semesters
                .Include(c => c.SchoolYear)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
