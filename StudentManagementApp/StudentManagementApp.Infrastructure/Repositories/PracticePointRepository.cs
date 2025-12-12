using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Models.PracticePoints;
using StudentManagementApp.Core.Models.Reports;
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
                .Include(c => c.Trainee).ThenInclude(c => c.Class)
                .Select(r => new PracticePointViewModel
                {
                    Id = r.Id,
                    TraineeName = r.Trainee != null ? r.Trainee.FullName : "",
                    ClassName = r.Trainee.Class != null ? r.Trainee.Class.Name : "",
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

        public async Task<List<PracticePointDetailDto>> GetPracticePointDetailReportAsync(DateTime fromDate, DateTime toDate)
        {
            return await _context.PracticePoints
                .Where(pp => pp.Time >= fromDate && pp.Time <= toDate && pp.IsActive)
                .Include(pp => pp.Trainee).ThenInclude(c => c.Class)
                .Select(pp => new PracticePointDetailDto
                {
                    Id = pp.Id,
                    TraineeName = pp.Trainee.FullName,
                    ClassName = pp.Trainee.Class.Name,
                    Content = pp.Content,
                    Point = pp.Point,
                    Time = pp.Time,
                    Description = pp.Description
                })
                .ToListAsync();
        }

        public async Task<List<PracticePointSummaryDto>> GetPracticePointSummaryReportAsync(DateTime fromDate, DateTime toDate, string timeRange)
        {
            return await _context.PracticePoints
                .Where(pp => pp.Time >= fromDate && pp.Time <= toDate && pp.IsActive)
                .GroupBy(pp => new
                {
                    pp.Content,
                    Period = timeRange == "day" ? pp.Time.Date :
                                    timeRange == "week" ? pp.Time.AddDays(-(int)pp.Time.DayOfWeek).Date :
                                    new DateTime(pp.Time.Year, pp.Time.Month, 1)
                })
                .Select(g => new PracticePointSummaryDto
                {
                    Content = g.Key.Content,
                    TotalPoints = g.Sum(pp => pp.Point),
                    Period = g.Key.Period
                })
                .ToListAsync();
        }
    }
}
