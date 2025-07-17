using System.Linq.Expressions;

namespace QuanLyHocVien.Infrastructure.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy,
            string includeProperties);
        Task<TEntity?> GetByIdAsync(int id);
        Task InsertAsync(TEntity entity);
        void Update(TEntity entityToUpdate);
        Task DeleteAsync(object id);
        void Delete(TEntity entityToDelete);
    }
}
