namespace Core.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public string? ImageUrl { get; set; }
        public Category? Category { get; set; }

        private Product() { }

        public Product(string id, string name, string description, decimal price, int stockQuantity, string imageUrl, Category category)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            StockQuantity = stockQuantity;
            ImageUrl = imageUrl;
            Category = category;
        }

        public Product(string name, string description, decimal price, int stockQuantity, string imageUrl, Category category)
        {
            Name = name;
            Description = description;
            Price = price;
            StockQuantity = stockQuantity;
            ImageUrl = imageUrl;
            Category = category;
        }
    }
}
