using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Misconducts;
using StudentManagementApp.Core.Models.Reports;

namespace StudentManagementApp.Core.Interfaces.Repositories
{
    public interface IMisconductRepository : IRepository<Misconduct>
    {
        Task<IEnumerable<MisconductViewModel>> GetMisconductsWithTraineeAsync();
        Task<Misconduct> GetMisconductWithDetailsAsync(int id);
        Task<List<Misconduct>> GetMisconductsWithTraineeFromDateToDateAsync(DateTime fromDate, DateTime toDate);
        Task<List<MisconductDetailDto>> GetMisconductDetailReportAsync(DateTime fromDate, DateTime toDate);
        Task<List<MisconductSummaryDto>> GetMisconductSummaryReportAsync(DateTime fromDate, DateTime toDate, string timeRange);
    }
}
