using QuanLyHocVien.Infrastructure.Repositories;

namespace QuanLyHocVien.Infrastructure.Configurations
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
    }
}
