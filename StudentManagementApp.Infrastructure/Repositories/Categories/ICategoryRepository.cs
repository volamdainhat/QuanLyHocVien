using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Categories;

namespace StudentManagementApp.Infrastructure.Repositories.Categories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<CategoryViewModel>> GetCategoriesWithTypeAsync(string type);
        Task<Category> GetCategoryWithDetailsAsync(int id);
    }
}
