using Core.Models;
using Core.Repositories;
using Infrastructure.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly GabiniDbContext _context;

        public ProductRepository(GabiniDbContext context)
        {
            _context = context;
        }

        public async Task<Product> SaveProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> GetProductById(string id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetAllProducts(string? search, string? categoryId)
        {
            if (string.IsNullOrEmpty(search) && string.IsNullOrEmpty(categoryId))
            {
                return await _context.Products.ToListAsync();
            }

            var query = _context.Products.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Name.ToUpper().Contains(search.ToUpper()));
            }

            if (!string.IsNullOrEmpty(categoryId))
            {
                query = query.Where(p => p.Category.Id == categoryId);
            }

            return await query.ToListAsync();
        }

        public async Task<bool> DeleteProduct(string id)
        {
            Product product = await GetProductById(id);
            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
