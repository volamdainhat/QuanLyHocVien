using StudentManagementApp.Core.Entities;

namespace StudentManagementApp.Infrastructure.Repositories.Subjects
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        Task<bool> CheckCodeExistsAsync(string code);
    }
}
