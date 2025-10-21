using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.GraduationScores;

namespace StudentManagementApp.Core.Interfaces.Repositories
{
    public interface IGraduationScoreRepository : IRepository<GraduationScore>
    {
        Task<IEnumerable<GraduationScoreViewModel>> GetGraduationScoreWithTraineeAsync();
        Task<GraduationScore> GetGraduationScoreWithDetailsAsync(int id);
        Task UpdateTraineeGraduationScoreAsync(int traineeId);
    }
}
