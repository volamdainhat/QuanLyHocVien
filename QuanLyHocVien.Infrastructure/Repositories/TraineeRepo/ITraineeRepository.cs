using QuanLyHocVien.Domain.Entities;

namespace QuanLyHocVien.Infrastructure.Repositories.TraineeRepo
{
    public interface ITraineeRepository : IRepository<Trainee>
    {
        Task<IEnumerable<Trainee>> SearchAsync(string keyword, int classId);
    }
}
