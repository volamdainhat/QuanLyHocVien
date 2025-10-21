using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.WeeklyCritiques;

namespace StudentManagementApp.Core.Interfaces.Repositories
{
    public interface IWeeklyCritiqueRepository : IRepository<WeeklyCritique>
    {
        Task<IEnumerable<WeeklyCritiqueViewModel>> GetWeeklyCritiqueWithTraineeAsync();
        Task<WeeklyCritique> GetWeeklyCritiqueWithDetailsAsync(int id);
    }
}
