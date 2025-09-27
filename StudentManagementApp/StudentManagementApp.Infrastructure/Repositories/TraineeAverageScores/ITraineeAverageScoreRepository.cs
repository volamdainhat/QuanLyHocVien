using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.TraineeAverageScores;

namespace StudentManagementApp.Infrastructure.Repositories.TraineeAverageScores
{
    public interface ITraineeAverageScoreRepository : IRepository<TraineeAverageScore>
    {
        Task<IEnumerable<TraineeAverageScoreViewModel>> GetTraineeAverageScoreWithTraineeSemesterAsync();
        Task<TraineeAverageScore> GetTraineeAverageScoreWithDetailsAsync(int id);
        Task UpdateTraineeAverageScoreAsync(int traineeId, int semesterId);
    }
}
