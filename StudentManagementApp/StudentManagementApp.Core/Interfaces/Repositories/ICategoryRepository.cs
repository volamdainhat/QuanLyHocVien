using StudentManagementApp.Core.Entities;
using StudentManagementApp.Core.Models.Categories;

namespace StudentManagementApp.Core.Interfaces.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<CategoryViewModel>> GetCategoriesWithTypeAsync(string type);
        Task<Category> GetCategoryWithDetailsAsync(int id);
    }
}
