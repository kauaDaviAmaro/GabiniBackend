using Core.Models;
using Core.DTOs;

namespace Core.Services
{
    public interface ICategoryService
    {
        Task<Category> CreateCategory(CategoryDTO category);
        Task<Category> UpdateCategory(string id, CategoryDTO category);
        Task<bool> DeleteCategory(string id);
        Task<Category> GetCategoryById(string id);
        Task<IEnumerable<Category>> GetAllCategories();
    }
}
