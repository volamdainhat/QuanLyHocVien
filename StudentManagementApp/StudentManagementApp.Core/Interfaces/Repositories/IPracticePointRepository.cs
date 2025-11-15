using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.PracticePoints;
using StudentManagementApp.Core.Models.Reports;

namespace StudentManagementApp.Core.Interfaces.Repositories
{
    public interface IPracticePointRepository : IRepository<PracticePoint>
    {
        Task<IEnumerable<PracticePointViewModel>> GetPracticePointsWithTraineeAsync();
        Task<PracticePoint> GetPracticePointWithDetailsAsync(int id);
        Task<List<PracticePoint>> GetPracticePointsWithTraineeFromDateToDateAsync(DateTime fromDate, DateTime toDate);
        Task<List<PracticePointDetailDto>> GetPracticePointDetailReportAsync(DateTime fromDate, DateTime toDate);
        Task<List<PracticePointSummaryDto>> GetPracticePointSummaryReportAsync(DateTime fromDate, DateTime toDate, string timeRange);
    }
}
