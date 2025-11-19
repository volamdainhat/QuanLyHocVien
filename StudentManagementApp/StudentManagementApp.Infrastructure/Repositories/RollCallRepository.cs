using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Models.Reports;
using StudentManagementApp.Infrastructure.Data;

namespace StudentManagementApp.Infrastructure.Repositories
{
    public class RollCallRepository : Repository<RollCall>, IRollCallRepository
    {
        public RollCallRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<RollCall>> GetRollCallFromDateToDateAsync(DateTime fromDate, DateTime toDate)
        {
            return await _context.RollCalls.Where(r => r.Date >= fromDate && r.Date <= toDate && r.IsActive).ToListAsync();
        }

        public async Task<List<RollCallDetailDto>> GetRollCallDetailReportAsync(DateTime fromDate, DateTime toDate)
        {
            return await _context.RollCalls
                .Where(rc => rc.Date >= fromDate && rc.Date <= toDate && rc.IsActive)
                .Select(rc => new RollCallDetailDto
                {
                    Id = rc.Id,
                    Date = rc.Date,
                    RollCaller = rc.RollCaller,
                    TotalStudents = rc.TotalStudents,
                    Present = rc.Present,
                    Absent = rc.Absent,
                    Percentage = $"{((double)rc.Present / rc.TotalStudents * 100):0.00}%",
                    Notes = rc.Notes
                })
                .ToListAsync();
        }

        public async Task<RollCallSummaryDto> GetRollCallSummaryReportAsync(DateTime fromDate, DateTime toDate)
        {
            var data = await _context.RollCalls
                .Where(rc => rc.Date >= fromDate && rc.Date <= toDate && rc.IsActive)
                .ToListAsync();

            return new RollCallSummaryDto
            {
                Period = fromDate,
                TotalSessions = data.Count,
                AverageAttendanceRate = data.Any() ? data.Average(rc => (double)rc.Present / rc.TotalStudents) * 100 : 0,
                MaxAbsent = data.Any() ? data.Max(rc => rc.Absent) : 0
            };
        }
    }
}
