using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Models.PracticePoints;
using StudentManagementApp.Infrastructure.Data;

namespace StudentManagementApp.Infrastructure.Repositories
{
    public class PracticePointRepository : Repository<PracticePoint>, IPracticePointRepository
    {
        public PracticePointRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<PracticePointViewModel>> GetPracticePointsWithTraineeAsync()
        {
            return await _context.PracticePoints
                .Include(c => c.Trainee)
                .Select(r => new PracticePointViewModel
                {
                    Id = r.Id,
                    TraineeName = r.Trainee != null ? r.Trainee.FullName : "",
                    Time = r.Time,
                    Content = r.Content,
                    Point = r.Point,
                    Description = r.Description,
                    IsActive = r.IsActive,
                    CreatedDate = r.CreatedDate,
                    ModifiedDate = r.ModifiedDate
                }).ToListAsync();
        }

        public async Task<PracticePoint> GetPracticePointWithDetailsAsync(int id)
        {
            return await _context.PracticePoints
                .Include(c => c.Trainee)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<PracticePoint>> GetPracticePointsWithTraineeFromDateToDateAsync(DateTime fromDate, DateTime toDate)
        {
            return await _context.PracticePoints
                .Where(p => p.Time >= fromDate && p.Time <= toDate && p.IsActive)
                .Include(p => p.Trainee)
                .ToListAsync();
        }
    }
}
