using StudentManagementApp.Core.Entities;

namespace StudentManagementApp.Core.Interfaces.Repositories
{
    public interface IRollCallRepository : IRepository<RollCall>
    {
        Task<List<RollCall>> GetRollCallFromDateToDateAsync(DateTime fromDate, DateTime toDate);
    }
}
