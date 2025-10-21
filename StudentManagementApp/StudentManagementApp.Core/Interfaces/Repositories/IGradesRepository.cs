using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Grades;

namespace StudentManagementApp.Core.Interfaces.Repositories
{
    public interface IGradesRepository : IRepository<Grades>
    {
        Task<IEnumerable<GradesViewModel>> GetGradesWithTraineeSubjectAsync();
        Task<Grades> GetGradesWithDetailsAsync(int id);
    }
}
