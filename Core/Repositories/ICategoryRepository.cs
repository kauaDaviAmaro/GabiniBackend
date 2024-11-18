using Core.Models;
using Core.DTOs;

namespace Core.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetCategoryById(string id);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<Category> CreateCategory(CategoryDTO category);
        Task<Category> UpdateCategory(string id, CategoryDTO category);
        Task<bool> DeleteCategory(string id);
    }
}
