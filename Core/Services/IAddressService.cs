using Core.Models;

namespace Core.Services
{
    public interface IAddressService
    {
        public Task<Address> GetAddressOrThrowException(string addressId);
    }
}
