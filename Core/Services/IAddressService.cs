using Core.DTOs;
using Core.Models;

namespace Core.Services
{
    public interface IAddressService
    {
        public Task<Address> SaveAddress(AddressDTO addressDTO, string userId);
    }
}
