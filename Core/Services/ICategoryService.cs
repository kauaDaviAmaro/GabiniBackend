using Core.Models;

namespace Core.Services
{
    public interface ICategoryService
    {
        Task<Category> CreateCategory(Category category);
        Task<Category> UpdateCategory(string id, Category category);
        Task<bool> DeleteCategory(string id);
        Task<Category> GetCategoryById(string id);
        Task<IEnumerable<Category>> GetAllCategories();
    }
}
