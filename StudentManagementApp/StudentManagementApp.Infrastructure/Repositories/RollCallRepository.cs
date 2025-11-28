using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Models.Reports;
using StudentManagementApp.Core.Models.RollCalls;
using StudentManagementApp.Infrastructure.Data;

namespace StudentManagementApp.Infrastructure.Repositories
{
    public class RollCallRepository : Repository<RollCall>, IRollCallRepository
    {
        public RollCallRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<RollCallViewModel>> GetRollCallsWithClassAsync()
        {
            return await (from rollcall in _context.RollCalls
                          join rcClass in _context.Classes on rollcall.ClassId equals rcClass.Id into classJoin
                          from classObj in classJoin.DefaultIfEmpty()
                          select new RollCallViewModel
                          {
                              Id = rollcall.Id,
                              Date = rollcall.Date,
                              ClassName = classObj != null ? classObj.Name : "",
                              RollCaller = rollcall.RollCaller,
                              TotalStudents = rollcall.TotalStudents,
                              Present = rollcall.Present,
                              Absent = rollcall.Absent,
                              Notes = rollcall.Notes,
                              IsActive = rollcall.IsActive,
                              CreatedDate = rollcall.CreatedDate,
                              ModifiedDate = rollcall.ModifiedDate
                          }).ToListAsync();
        }

        public async Task<RollCall> GetRollCallWithDetailsAsync(int id)
        {
            return await _context.RollCalls
                .Include(c => c.Class)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<RollCall>> GetRollCallFromDateToDateAsync(DateTime fromDate, DateTime toDate)
        {
            return await _context.RollCalls.Where(r => r.Date >= fromDate && r.Date <= toDate && r.IsActive).ToListAsync();
        }

        public async Task<List<RollCallDetailDto>> GetRollCallDetailReportAsync(DateTime fromDate, DateTime toDate)
        {
            return await _context.RollCalls
                .Include(rc => rc.Class)
                .Where(rc => rc.Date >= fromDate && rc.Date <= toDate && rc.IsActive)
                .Select(rc => new RollCallDetailDto
                {
                    Id = rc.Id,
                    Date = rc.Date,
                    ClassName = rc.Class.Name,
                    RollCaller = rc.RollCaller,
                    TotalStudents = rc.TotalStudents,
                    Present = rc.Present,
                    Absent = rc.Absent,
                    Percentage = $"{((double)rc.Present / rc.TotalStudents * 100):0.00}%",
                    Notes = rc.Notes
                })
                .ToListAsync();
        }

        //public async Task<RollCallSummaryDto> GetRollCallSummaryReportAsync(DateTime fromDate, DateTime toDate)
        //{
        //    var data = await _context.RollCalls
        //        .Where(rc => rc.Date >= fromDate && rc.Date <= toDate && rc.IsActive)
        //        .ToListAsync();

        //    return new RollCallSummaryDto
        //    {
        //        Period = fromDate,
        //        TotalSessions = data.Count,
        //        AverageAttendanceRate = data.Any() ? data.Average(rc => (double)rc.Present / rc.TotalStudents) * 100 : 0,
        //        MaxAbsent = data.Any() ? data.Max(rc => rc.Absent) : 0
        //    };
        //}

        public async Task<List<RollCallSummaryDto>> GetRollCallSummaryReportAsync(DateTime fromDate, DateTime toDate)
        {
            var query = _context.RollCalls
                .Where(rc => rc.Date >= fromDate && rc.Date <= toDate && rc.IsActive)
                .GroupBy(rc => new { rc.ClassId, rc.Class.Name })
                .Select(g => new RollCallSummaryDto
                {
                    FromDate = fromDate,
                    ToDate = toDate,
                    ClassName = g.Key.Name,
                    TotalSessions = g.Count(),
                    AverageAttendanceRate = Math.Round(g.Average(rc =>
                        rc.TotalStudents > 0 ? (double)rc.Present / rc.TotalStudents * 100 : 0), 2),
                    MaxAbsent = g.Max(rc => rc.Absent)
                });

            return await query.ToListAsync();
        }

    }
}
