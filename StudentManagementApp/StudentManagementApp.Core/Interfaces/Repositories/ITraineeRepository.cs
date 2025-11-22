using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Trainees;

namespace StudentManagementApp.Core.Interfaces.Repositories
{
    public interface ITraineeRepository : IRepository<Trainee>
    {
        Task<IEnumerable<TraineeViewModel>> GetTraineesWithClassAsync();
        Task<Trainee> GetTraineeWithDetailsAsync(int id);
        Task<int> GetTotalTraineeAsync();
        Task<List<TraineeByClassModel>> GetTotalTraineeByClassAsync(); 
        Task<List<Trainee>> GetTraineesActiveAsync();
        Task<List<Trainee>> GetTraineesByClassIdAsync(int classId);
    }
}
