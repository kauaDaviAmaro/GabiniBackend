using Core.Models;
using Core.Repositories;
using Core.DTOs;
using Core.Services;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> CreateCategory(CategoryDTO category)
        {
            return await _repository.CreateCategory(category);
        }

        public async Task<Category> GetCategoryById(string id)
        {
            return await _repository.GetCategoryById(id);
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _repository.GetAllCategories();
        }

        public async Task<Category> UpdateCategory(string id, CategoryDTO category)
        {
            return await _repository.UpdateCategory(id, category);
        }

        public async Task<bool> DeleteCategory(string id)
        {
            return await _repository.DeleteCategory(id);
        }
    }
}
