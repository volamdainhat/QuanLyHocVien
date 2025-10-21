using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.TraineeAverageScores;

namespace StudentManagementApp.Core.Interfaces.Repositories
{
    public interface ITraineeAverageScoreRepository : IRepository<TraineeAverageScore>
    {
        Task<IEnumerable<TraineeAverageScoreViewModel>> GetTraineeAverageScoreWithTraineeSemesterAsync();
        Task<TraineeAverageScore> GetTraineeAverageScoreWithDetailsAsync(int id);
        Task UpdateTraineeAverageScoreAsync(int traineeId, int semesterId);
    }
}
