using Microsoft.EntityFrameworkCore;
using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Categories;
using StudentManagementApp.Infrastructure.Data;

namespace StudentManagementApp.Infrastructure.Repositories.Categories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategoriesWithTypeAsync(string type)
        {
            return await _context.Categories
                .Where(c => c.Type == type)
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    ParentId = c.ParentId,
                    Type = c.Type,
                    Code = c.Code,
                    Name = c.Name,
                    Description = c.Description,
                    SortOrder = c.SortOrder,
                    CreatedDate = c.CreatedDate,
                    ModifiedDate = c.ModifiedDate,
                    IsActive = c.IsActive
                })
                .ToListAsync();
        }

        public async Task<Category> GetCategoryWithDetailsAsync(int id)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
