namespace Core.Models
{
    public class Address
    {
        public string Id { get; set; }
        public User user { get; set; }

        private Address() { }

        public Address(string id, User user)
        {
            Id = id;
            User user = user;
        }
    }
}
