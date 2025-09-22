using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Schedules;

namespace StudentManagementApp.Infrastructure.Repositories.Schedules
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        Task<IEnumerable<ScheduleViewModel>> GetScheduleWithClassSubjectAsync();
        Task<Schedule> GetScheduleWithDetailsAsync(int id);
    }
}
