using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Schedules;
using StudentManagementApp.Infrastructure.Data;

namespace StudentManagementApp.Infrastructure.Repositories.Schedules
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
                              Date = schedule.Date
                          }).ToListAsync();
        }

        public async Task<Schedule> GetScheduleWithDetailsAsync(int id)
        {
            return await _context.Schedules
                .Include(c => c.Class)
                .Include(c => c.Subject)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
