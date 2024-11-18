using Microsoft.AspNetCore.Mvc;
using Core.Models;
using Core.Services;
using Core.DTOs;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(string? search, string? categoryId)
        {
            IEnumerable<Product> products = await _productService.GetAllProducts(search, categoryId);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            Product product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductDTO productDTO)
        {
            Product product = await _productService.CreateProduct(productDTO);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> PutProduct(string id, ProductDTO productDTO)
        {
            Product updatedProduct = await _productService.UpdateProduct(id, productDTO);
            if (updatedProduct == null)
            {
                return NotFound();
            }
            return CreatedAtAction(nameof(GetProduct), new { id = updatedProduct.Id }, updatedProduct);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            bool deleted = await _productService.DeleteProduct(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost("{id}/image")]
        public async Task<IActionResult> PostProductImage(string id, IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                return BadRequest("No image found");
            }

            using var memoryStream = new MemoryStream();
            await image.CopyToAsync(memoryStream);

            FileData fileData = new FileData
            {
                FileName = image.FileName,
                Content = memoryStream.ToArray(),
                ContentType = image.ContentType,
                Extension = Path.GetExtension(image.FileName),
            };

            string imageUrl = await _productService.SaveProductImage(fileData, id);
            return CreatedAtAction(nameof(PostProductImage), imageUrl);
        }
    }
}
