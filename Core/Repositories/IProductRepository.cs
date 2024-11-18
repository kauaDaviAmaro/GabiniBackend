using Core.Models;

public interface IProductRepository
{
    Task<Product> GetProductById(string id);
    Task<IEnumerable<Product>> GetAllProducts(string? search, string? categoryId);
    Task<Product> SaveProduct(Product product);
    Task<bool> DeleteProduct(string id);
    Task<Product?> UpdateProduct(Product product);
}
