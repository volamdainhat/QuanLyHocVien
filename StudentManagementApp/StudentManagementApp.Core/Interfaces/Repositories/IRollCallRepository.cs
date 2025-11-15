using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Reports;

namespace StudentManagementApp.Core.Interfaces.Repositories
{
    public interface IRollCallRepository : IRepository<RollCall>
    {
        Task<List<RollCall>> GetRollCallFromDateToDateAsync(DateTime fromDate, DateTime toDate);
        Task<List<RollCallDetailDto>> GetRollCallDetailReportAsync(DateTime fromDate, DateTime toDate);
        Task<RollCallSummaryDto> GetRollCallSummaryReportAsync(DateTime fromDate, DateTime toDate);
    }
}
