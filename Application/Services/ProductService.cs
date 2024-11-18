using Core.DTOs;
using Core.Models;
using Core.Repositories;
using Core.Services;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IImageService _imageService;
        private readonly ICategoryRepository _categoryService;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryService, IImageService imageService)
        {
            _productRepository = productRepository;
            _categoryService = categoryService;
            _imageService = imageService;
        }

        public async Task<Product> GetProductById(string id)
        {
            return await _productRepository.GetProductById(id);
        }

        public async Task<Product> CreateProduct(ProductDTO productDTO)
        {
            Category category = await _categoryService.GetCategoryById(productDTO.CategoryId);
            Product product = new Product(productDTO.Name, productDTO.Description, productDTO.Price, productDTO.StockQuantity, null, category);
            return await _productRepository.SaveProduct(product);
        }

        public async Task<Product> UpdateProduct(string id, ProductDTO productDTO)
        {
            Product product = await _productRepository.GetProductById(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            product.Name = productDTO.Name;
            product.Description = productDTO.Description;
            product.Price = productDTO.Price;
            product.StockQuantity = productDTO.StockQuantity;
            product.ImageUrl = productDTO.ImageUrl;
            product.Category = await _categoryService.GetCategoryById(productDTO.CategoryId);

            return await _productRepository.UpdateProduct(product);
        }

        public async Task<bool> DeleteProduct(string id)
        {
            Product product = await _productRepository.GetProductById(id);
            if (product == null)
            {
                return false;
            }

            await _productRepository.DeleteProduct(id);
            return true;
        }

        public async Task<IEnumerable<Product>> GetAllProducts(string? search, string? categoryId)
        {
            return await _productRepository.GetAllProducts(search, categoryId);
        }

        public async Task<string> SaveProductImage(FileData file, string id)
        {
            Product product = await _productRepository.GetProductById(id);
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            string imageUrl = await _imageService.UploadImage(file, "products", id);
            product.ImageUrl = imageUrl;
            await _productRepository.UpdateProduct(product);

            return imageUrl;
        }
    }
}
