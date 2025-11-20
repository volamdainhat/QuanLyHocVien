using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Reports;
using StudentManagementApp.Core.Models.RollCalls;

namespace StudentManagementApp.Core.Interfaces.Repositories
{
    public interface IRollCallRepository : IRepository<RollCall>
    {
        Task<IEnumerable<RollCallViewModel>> GetRollCallsWithClassAsync();
        Task<RollCall> GetRollCallWithDetailsAsync(int id);
        Task<List<RollCall>> GetRollCallFromDateToDateAsync(DateTime fromDate, DateTime toDate);
        Task<List<RollCallDetailDto>> GetRollCallDetailReportAsync(DateTime fromDate, DateTime toDate);
        Task<List<RollCallSummaryDto>> GetRollCallSummaryReportAsync(DateTime fromDate, DateTime toDate);
    }
}
