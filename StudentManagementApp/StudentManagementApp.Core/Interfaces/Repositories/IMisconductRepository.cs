using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Misconducts;

namespace StudentManagementApp.Core.Interfaces.Repositories
{
    public interface IMisconductRepository : IRepository<Misconduct>
    {
        Task<IEnumerable<MisconductViewModel>> GetMisconductsWithTraineeAsync();
        Task<Misconduct> GetMisconductWithDetailsAsync(int id);
        Task<List<Misconduct>> GetMisconductsWithTraineeFromDateToDateAsync(DateTime fromDate, DateTime toDate);
    }
}
