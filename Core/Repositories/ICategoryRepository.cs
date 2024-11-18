using Core.Models;

namespace Core.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryById(string id);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> CreateCategory(Category category);
        Task<Category> UpdateCategory(string id, Category category);
        Task<bool> DeleteCategory(string id);
    }
}
