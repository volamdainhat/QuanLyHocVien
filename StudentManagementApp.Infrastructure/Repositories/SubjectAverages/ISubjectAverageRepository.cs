using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Trainees;

namespace StudentManagementApp.Infrastructure.Repositories.SubjectAverages
{
    public interface ISubjectAverageRepository : IRepository<SubjectAverage>
    {
        Task<IEnumerable<SubjectAverageViewModel>> GetSubjectAverageWithSubjectTraineeAsync();
        Task<SubjectAverage> GetSubjectAverageWithDetailsAsync(int id);
        Task UpdateTraineeSubjectAverageAsync(int subjectId, int traineeId);
    }
}
