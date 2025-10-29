using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Schedules;

namespace StudentManagementApp.Core.Interfaces.Repositories
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        Task<IEnumerable<ScheduleViewModel>> GetScheduleWithClassSubjectAsync();
        Task<Schedule> GetScheduleWithDetailsAsync(int id);
        Task<List<ScheduleForTodayModel>> GetScheduleForTodayAsync();
        Task<List<ScheduleForTodayModel>> GetScheduleForThisWeekAsync();
        Task<List<ScheduleForTodayModel>> GetScheduleForThisMonthAsync();
    }
}
