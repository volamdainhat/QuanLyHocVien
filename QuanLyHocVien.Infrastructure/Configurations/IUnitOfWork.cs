using QuanLyHocVien.Infrastructure.Repositories;

namespace QuanLyHocVien.Infrastructure.Configurations
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity>? GetRepository<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}
