using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Semesters;

namespace StudentManagementApp.Core.Interfaces.Repositories
{
    public interface ISemesterRepository : IRepository<Semester>
    {
        Task<IEnumerable<SemesterViewModel>> GetSemestersWithSchoolYearAsync();
        Task<Semester> GetSemesterWithDetailsAsync(int id);
    }
}
