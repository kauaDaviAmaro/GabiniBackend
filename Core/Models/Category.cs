namespace Core.Models
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Category(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
