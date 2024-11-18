using Core.DTOs;
using Core.Models;

namespace Core.Services
{
    public interface IAddressService
    {
        public Task<Address> SaveAddress(AddressDTO addressDTO, string userId);
        public Task<IEnumerable<Address>> GetAddresses(string userId);
        public Task<Address> UpdateAddress(AddressDTO addressDTO, string userId);
        public Task<Address> DeleteAddress(string id);
    }
}
