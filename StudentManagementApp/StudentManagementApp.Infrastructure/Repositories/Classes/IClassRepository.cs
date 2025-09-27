using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Classes;

namespace StudentManagementApp.Infrastructure.Repositories.Classes
{
    public interface IClassRepository : IRepository<Class>
    {
        Task<IEnumerable<ClassViewModel>> GetClassesWithSchoolYearAsync();
        Task<Class> GetClassWithDetailsAsync(int id);
    }
}
