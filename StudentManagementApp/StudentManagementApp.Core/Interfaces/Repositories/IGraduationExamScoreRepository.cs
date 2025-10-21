using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.GraduationExamScores;

namespace StudentManagementApp.Core.Interfaces.Repositories
{
    public interface IGraduationExamScoreRepository : IRepository<GraduationExamScore>
    {
        Task<IEnumerable<GraduationExamScoreViewModel>> GetGraduationExamScoreWithTraineeAsync();
        Task<GraduationExamScore> GetGraduationExamScoreWithDetailsAsync(int id);
    }
}
