using Core.Models;

namespace Core.DTOs
{
    public class AddressDTO
    {
        public string street { get; set; }
        public string number { get; set; }
        public string neighborhood { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
        public User user { get; set; }
    }
}
