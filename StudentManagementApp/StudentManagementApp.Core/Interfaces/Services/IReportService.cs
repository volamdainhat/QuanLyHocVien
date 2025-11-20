using StudentManagementApp.Core.Models.Reports;

namespace StudentManagementApp.Core.Interfaces.Services
{
    public interface IReportService
    {
        Task<byte[]> GenerateTraineeReportAsync(DateTime fromDate, DateTime toDate);
        Task<byte[]> GenerateTimeReportAsync(DateTime fromDate, DateTime toDate, string reportType);

        // Misconduct Reports
        Task<List<MisconductDetailDto>> GetMisconductDetailReportAsync(DateTime date, string timeRange);
        Task<List<MisconductSummaryDto>> GetMisconductSummaryReportAsync(DateTime date, string timeRange);

        // PracticePoint Reports
        Task<List<PracticePointDetailDto>> GetPracticePointDetailReportAsync(DateTime date, string timeRange);
        Task<List<PracticePointSummaryDto>> GetPracticePointSummaryReportAsync(DateTime date, string timeRange);

        // RollCall Reports
        Task<List<RollCallDetailDto>> GetRollCallDetailReportAsync(DateTime date, string timeRange);
        Task<List<RollCallSummaryDto>> GetRollCallSummaryReportAsync(DateTime date, string timeRange);

    }
}
