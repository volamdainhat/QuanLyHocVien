using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.PracticePoints;

namespace StudentManagementApp.Core.Interfaces.Repositories
{
    public interface IPracticePointRepository : IRepository<PracticePoint>
    {
        Task<IEnumerable<PracticePointViewModel>> GetPracticePointsWithTraineeAsync();
        Task<PracticePoint> GetPracticePointWithDetailsAsync(int id);
        Task<List<PracticePoint>> GetPracticePointsWithTraineeFromDateToDateAsync(DateTime fromDate, DateTime toDate);
    }
}
