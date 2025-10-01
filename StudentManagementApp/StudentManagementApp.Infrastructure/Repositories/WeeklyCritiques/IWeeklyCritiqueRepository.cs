using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.WeeklyCritiques;

namespace StudentManagementApp.Infrastructure.Repositories.WeeklyCritiques
{
    public interface IWeeklyCritiqueRepository : IRepository<WeeklyCritique>
    {
        Task<IEnumerable<WeeklyCritiqueViewModel>> GetWeeklyCritiqueWithTraineeAsync();
        Task<WeeklyCritique> GetWeeklyCritiqueWithDetailsAsync(int id);
    }
}
