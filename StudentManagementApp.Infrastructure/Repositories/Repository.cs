using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Infrastructure.Data;
using System.Linq.Expressions;

namespace StudentManagementApp.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<T> _entities;

        public Repository(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id) => await _entities.FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync() => await _entities.ToListAsync();

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
            => await _entities.Where(predicate).ToListAsync();

        public async Task AddAsync(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync(); // Tự động validation
        }

        public async Task AddRangeAsync(List<T> entity)
        {
            foreach (var item in entity)
            {
                item.CreatedDate = DateTime.Now;
            }
            await _entities.AddRangeAsync(entity);
            await _context.SaveChangesAsync(); // Tự động validation
        }

        public async Task UpdateAsync(T entity)
        {
            entity.ModifiedDate = DateTime.Now;
            _entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync(); // Tự động validation
        }

        public async Task DeleteAsync(T entity)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync(); // Tự động validation
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
            => predicate == null ? await _entities.CountAsync() : await _entities.CountAsync(predicate);
    }
}
