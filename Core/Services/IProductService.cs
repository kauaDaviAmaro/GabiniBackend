using Core.DTOs;
using Core.Models;

namespace Core.Services {
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProducts(string? search, string? categoryId);
        Task<Product> GetProductById(string id);
        Task<Product> CreateProduct(ProductDTO productDTO);
        Task<Product> UpdateProduct(string id, ProductDTO productDTO);
        Task<bool> DeleteProduct(string id);
        Task<string> SaveProductImage(FileData file, string id);
    }
}