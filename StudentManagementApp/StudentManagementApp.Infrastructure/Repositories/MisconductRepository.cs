using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Models.Misconducts;
using StudentManagementApp.Core.Models.Reports;
using StudentManagementApp.Infrastructure.Data;

namespace StudentManagementApp.Infrastructure.Repositories
{
    public class MisconductRepository : Repository<Misconduct>, IMisconductRepository
    {
        public MisconductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MisconductViewModel>> GetMisconductsWithTraineeAsync()
        {
            return await (from misconduct in _context.Misconducts
                          join trainee in _context.Trainees on misconduct.TraineeId equals trainee.Id into traineeJoin
                          from traineeObj in traineeJoin.DefaultIfEmpty()
                          join category in _context.Categories on
                              new { Code = misconduct.Type, Type = "MisconductType" }
                              equals new { category.Code, category.Type } into categoryJoin
                          from misconductTypeObj in categoryJoin.DefaultIfEmpty()
                          select new MisconductViewModel
                          {
                              Id = misconduct.Id,
                              TraineeName = traineeObj != null ? traineeObj.FullName : "",
                              Type = misconductTypeObj != null ? misconductTypeObj.Name : "",
                              Time = misconduct.Time,
                              Description = misconduct.Description,
                              IsActive = misconduct.IsActive,
                              CreatedDate = misconduct.CreatedDate,
                              ModifiedDate = misconduct.ModifiedDate
                          }).ToListAsync();
        }

        public async Task<Misconduct> GetMisconductWithDetailsAsync(int id)
        {
            return await _context.Misconducts
                .Include(c => c.Trainee)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Misconduct>> GetMisconductsWithTraineeFromDateToDateAsync(DateTime fromDate, DateTime toDate)
        {
            return await _context.Misconducts.Where(m => m.Time >= fromDate && m.Time <= toDate && m.IsActive)
                .Include(m => m.Trainee)
                .ToListAsync();
        }

        public async Task<List<MisconductDetailDto>> GetMisconductDetailReportAsync(DateTime fromDate, DateTime toDate)
        {
            return await _context.Misconducts
                .Where(m => m.Time >= fromDate && m.Time <= toDate && m.IsActive)
                .Include(m => m.Trainee)
                .Select(m => new MisconductDetailDto
                {
                    Id = m.Id,
                    TraineeName = m.Trainee.FullName,
                    Type = m.Type,
                    Time = m.Time,
                    Description = m.Description
                })
                .ToListAsync();
        }

        public async Task<List<MisconductSummaryDto>> GetMisconductSummaryReportAsync(DateTime fromDate, DateTime toDate, string timeRange)
        {
            return await _context.Misconducts
                .Where(m => m.Time >= fromDate && m.Time <= toDate && m.IsActive)
                .GroupBy(m => new {
                    m.Type,
                    Period = timeRange == "day" ? m.Time.Date :
                                    timeRange == "week" ? m.Time.AddDays(-(int)m.Time.DayOfWeek).Date :
                                    new DateTime(m.Time.Year, m.Time.Month, 1)
                })
                .Select(g => new MisconductSummaryDto
                {
                    Type = g.Key.Type,
                    Count = g.Count(),
                    Period = g.Key.Period
                })
                .ToListAsync();
        }
    }
}
