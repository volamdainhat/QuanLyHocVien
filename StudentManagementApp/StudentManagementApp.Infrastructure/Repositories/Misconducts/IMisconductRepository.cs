using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Misconducts;

namespace StudentManagementApp.Infrastructure.Repositories.Misconducts
{
    public interface IMisconductRepository : IRepository<Misconduct>
    {
        Task<IEnumerable<MisconductViewModel>> GetMisconductsWithTraineeAsync();
        Task<Misconduct> GetMisconductWithDetailsAsync(int id);
    }
}
