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
                          join classes in _context.Classes on traineeObj.ClassId equals classes.Id into classJoin
                          from classObj in classJoin.DefaultIfEmpty()
                          join category in _context.Categories on
                              new { Code = misconduct.Type, Type = "MisconductType" }
                              equals new { category.Code, category.Type } into categoryJoin
                          from misconductTypeObj in categoryJoin.DefaultIfEmpty()
                          select new MisconductViewModel
                          {
                              Id = misconduct.Id,
                              TraineeName = traineeObj != null ? traineeObj.FullName : "",
                              ClassId = classObj != null ? classObj.Id : 0,
                              ClassName = classObj != null ? classObj.Name : "",
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
            return await (from misconduct in _context.Misconducts
                          join trainee in _context.Trainees on misconduct.TraineeId equals trainee.Id into traineeJoin
                          from traineeObj in traineeJoin.DefaultIfEmpty()
                          join classses in _context.Classes on traineeObj.ClassId equals classses.Id into classesJoin
                          from classesObj in classesJoin.DefaultIfEmpty()
                          join category in _context.Categories on
                              new { Code = misconduct.Type, Type = "MisconductType" }
                              equals new { category.Code, category.Type } into categoryJoin
                          from misconductTypeObj in categoryJoin.DefaultIfEmpty()
                          select new MisconductDetailDto
                          {
                              Id = misconduct.Id,
                              TraineeName = misconduct.Trainee.FullName,
                              ClassName = classesObj.Name,
                              Type = misconductTypeObj != null ? misconductTypeObj.Name : "",
                              Time = misconduct.Time,
                              Description = misconduct.Description
                          }).ToListAsync();
        }

        public async Task<List<MisconductSummaryDto>> GetMisconductSummaryReportAsync(DateTime fromDate, DateTime toDate, string timeRange)
        {
            return await (from misconduct in _context.Misconducts
                          join category in _context.Categories on
                              new { Code = misconduct.Type, Type = "MisconductType" }
                              equals new { category.Code, category.Type } into categoryJoin
                          from misconductTypeObj in categoryJoin.DefaultIfEmpty()
                          where misconduct.Time >= fromDate && misconduct.Time <= toDate && misconduct.IsActive
                          group misconduct by new
                          {
                              misconduct.Type,
                              TypeName = misconductTypeObj != null ? misconductTypeObj.Name : "",
                              Period = timeRange == "day" ? misconduct.Time.Date :
                                      timeRange == "week" ? misconduct.Time.AddDays(-(int)misconduct.Time.DayOfWeek).Date :
                                      new DateTime(misconduct.Time.Year, misconduct.Time.Month, 1)
                          } into g
                          select new MisconductSummaryDto
                          {
                              Type = g.Key.TypeName,
                              Count = g.Count(),
                              Period = g.Key.Period
                          }).ToListAsync();
        }
    }
}
