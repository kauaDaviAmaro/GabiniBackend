namespace Core.Models
{
    public class Address
    {
        public string Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public User User { get; set; }

        private Address() { }

        public Address(string id, string street, string number, string neighborhood, string city, string state, string zipCode, User user)
        {
            Id = id;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
            User = user;
        }

        public Address(string street, string number, string neighborhood, string city, string state, string zipCode, User user)
        {
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            ZipCode = zipCode;
            User = user;
        }
    }
}
