using Core.Models;

namespace Core.Repositories {
    public interface IProductRepository
    {
        Task<Product> GetProductById(string id);
        Task<IEnumerable<Product>> GetAllProducts(string? search, string? categoryId);
        Task<Product> SaveProduct(Product product);
        Task<bool> DeleteProduct(string id);
        Task<Product?> UpdateProduct(Product product);
    }
}