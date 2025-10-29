using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Interfaces.Repositories;
using StudentManagementApp.Core.Models.Schedules;
using StudentManagementApp.Infrastructure.Data;

namespace StudentManagementApp.Infrastructure.Repositories
{
    public class ScheduleRepository : Repository<Schedule>, IScheduleRepository
    {
        public ScheduleRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ScheduleViewModel>> GetScheduleWithClassSubjectAsync()
        {
            return await (from schedule in _context.Schedules
                          join classEntity in _context.Classes on schedule.ClassId equals classEntity.Id into classJoin
                          from classObj in classJoin.DefaultIfEmpty()
                          join subject in _context.Subjects on schedule.SubjectId equals subject.Id into subjectJoin
                          from subjectObj in subjectJoin.DefaultIfEmpty()
                          join period in _context.Categories on
                              new { Code = schedule.Period, Type = "SchedulePeriod" }
                              equals new { period.Code, period.Type } into periodJoin
                          from periodObj in periodJoin.DefaultIfEmpty()
                          select new ScheduleViewModel
                          {
                              Id = schedule.Id,
                              ClassName = classObj != null ? classObj.Name : "",
                              SubjectId = subjectObj != null ? subjectObj.Name : "",
                              Room = schedule.Room,
                              Period = periodObj != null ? periodObj.Name : "",
                              Date = schedule.Date,
                              CreatedDate = schedule.CreatedDate,
                              ModifiedDate = schedule.ModifiedDate,
                              IsActive = schedule.IsActive
                          })
                          .ToListAsync();
        }

        public async Task<Schedule> GetScheduleWithDetailsAsync(int id)
        {
            return await _context.Schedules
                .Include(c => c.Class)
                .Include(c => c.Subject)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<ScheduleForTodayModel>> GetScheduleForTodayAsync()
        {
            DateTime today = DateTime.Now.Date;

            return await (from schedule in _context.Schedules
                          where schedule.Date.Date == today
                          join classEntity in _context.Classes on schedule.ClassId equals classEntity.Id into classJoin
                          from classObj in classJoin.DefaultIfEmpty()
                          join subject in _context.Subjects on schedule.SubjectId equals subject.Id into subjectJoin
                          from subjectObj in subjectJoin.DefaultIfEmpty()
                          join period in _context.Categories on
                              new { Code = schedule.Period, Type = "SchedulePeriod" }
                              equals new { period.Code, period.Type } into periodJoin
                          from periodObj in periodJoin.DefaultIfEmpty()
                          select new ScheduleForTodayModel
                          {
                              Id = schedule.Id,
                              ClassName = classObj != null ? classObj.Name : "",
                              SubjectId = subjectObj != null ? subjectObj.Name : "",
                              Room = schedule.Room,
                              Period = periodObj != null ? periodObj.Name : "",
                              Date = schedule.Date.Date
                          })
                          .OrderBy(s => s.Date)
                          .ToListAsync();
        }

        public async Task<List<ScheduleForTodayModel>> GetScheduleForThisWeekAsync()
        {
            // Lấy ngày đầu tuần (Thứ 2) và cuối tuần (Chủ nhật)
            DateTime today = DateTime.Today;
            int daysSinceMonday = ((int)today.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
            DateTime startOfWeek = today.AddDays(-daysSinceMonday).Date;
            DateTime endOfWeek = startOfWeek.AddDays(6).Date;

            return await (from schedule in _context.Schedules
                          where schedule.Date.Date >= startOfWeek && schedule.Date.Date <= endOfWeek
                          join classEntity in _context.Classes on schedule.ClassId equals classEntity.Id into classJoin
                          from classObj in classJoin.DefaultIfEmpty()
                          join subject in _context.Subjects on schedule.SubjectId equals subject.Id into subjectJoin
                          from subjectObj in subjectJoin.DefaultIfEmpty()
                          join period in _context.Categories on
                              new { Code = schedule.Period, Type = "SchedulePeriod" }
                              equals new { period.Code, period.Type } into periodJoin
                          from periodObj in periodJoin.DefaultIfEmpty()
                          select new ScheduleForTodayModel
                          {
                              Id = schedule.Id,
                              ClassName = classObj != null ? classObj.Name : "",
                              SubjectId = subjectObj != null ? subjectObj.Name : "",
                              Room = schedule.Room,
                              Period = periodObj != null ? periodObj.Name : "",
                              Date = schedule.Date.Date
                          })
                          .OrderBy(s => s.Date)
                          .ToListAsync();
        }

        public async Task<List<ScheduleForTodayModel>> GetScheduleForThisMonthAsync()
        {
            // Lấy ngày đầu tháng và cuối tháng hiện tại
            DateTime firstDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            return await (from schedule in _context.Schedules
                          where schedule.Date.Date >= firstDayOfMonth && schedule.Date.Date <= lastDayOfMonth
                          join classEntity in _context.Classes on schedule.ClassId equals classEntity.Id into classJoin
                          from classObj in classJoin.DefaultIfEmpty()
                          join subject in _context.Subjects on schedule.SubjectId equals subject.Id into subjectJoin
                          from subjectObj in subjectJoin.DefaultIfEmpty()
                          join period in _context.Categories on
                              new { Code = schedule.Period, Type = "SchedulePeriod" }
                              equals new { period.Code, period.Type } into periodJoin
                          from periodObj in periodJoin.DefaultIfEmpty()
                          select new ScheduleForTodayModel
                          {
                              Id = schedule.Id,
                              ClassName = classObj != null ? classObj.Name : "",
                              SubjectId = subjectObj != null ? subjectObj.Name : "",
                              Room = schedule.Room,
                              Period = periodObj != null ? periodObj.Name : "",
                              Date = schedule.Date.Date
                          })
                          .OrderBy(s => s.Date)
                          .ToListAsync();
        }
    }
}
