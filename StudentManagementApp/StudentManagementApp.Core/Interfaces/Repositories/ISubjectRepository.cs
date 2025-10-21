using StudentManagementApp.Core.Entities;

namespace StudentManagementApp.Core.Interfaces.Repositories
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        Task<bool> CheckCodeExistsAsync(string code);
    }
}
