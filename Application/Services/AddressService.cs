using Core.Models;
using Core.Repositories;
using Core.Services;

namespace Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public Task<Address> GetAddressOrThrowException(string addressId)
        {
            throw new NotImplementedException();
        }
    }
}
