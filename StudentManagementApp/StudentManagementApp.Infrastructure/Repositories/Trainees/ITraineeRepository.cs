using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Trainees;

namespace StudentManagementApp.Infrastructure.Repositories.Trainees
{
    public interface ITraineeRepository : IRepository<Trainee>
    {
        Task<IEnumerable<TraineeViewModel>> GetTraineesWithClassAsync();
        Task<Trainee> GetTraineeWithDetailsAsync(int id);
    }
}
