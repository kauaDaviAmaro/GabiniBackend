using Core.DTOs;
using Core.Models;
using Core.Repositories;
using Core.Services;

namespace Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IUserService _userService;
        private readonly IAddressRepository _addressRepository;


        public AddressService(IAddressRepository addressRepository, IUserService userService)
        {
            _addressRepository = addressRepository;
            _userService = userService;
        }

        public async Task<Address> SaveAddress(AddressDTO addressDTO, string userId)
        {
            User user = await _userService.GetUserById(userId);

            Address address = new Address(addressDTO.street, addressDTO.number, addressDTO.neighborhood, addressDTO.city, addressDTO.state, addressDTO.zipCode, user);
            return await _addressRepository.SaveAddress(address);
        }
    }
}
