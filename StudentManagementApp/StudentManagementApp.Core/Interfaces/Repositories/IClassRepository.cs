using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Classes;

namespace StudentManagementApp.Core.Interfaces.Repositories
{
    public interface IClassRepository : IRepository<Class>
    {
        Task<IEnumerable<ClassViewModel>> GetClassesWithSchoolYearAsync();
        Task<Class> GetClassWithDetailsAsync(int id);
        Task UpdateTotalStudentsAsync(int id);
        Task UpdateTotalStudentsForAllClassAsync();
    }
}
