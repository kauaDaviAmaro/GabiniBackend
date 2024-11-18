using Core.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        private readonly IAuthService _authService;

        public AddressController(IAddressService addressService, IAuthService authService)
        {
            _addressService = addressService;
            _authService = authService;
        }

        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(AddressDTO addressDTO)
        {
            string userId = _authService.GetAuthenticatedUserId(User);

            Address address = await _addressService.SaveAddress(addressDTO, userId);

            return CreatedAtAction(nameof(PostAddress), new { id = address.Id }, address);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
        {
            string userId = _authService.GetAuthenticatedUserId(User);
            IEnumerable<Address> address = await _addressService.GetAddresses(userId);

            return CreatedAtAction(nameof(GetAddresses), address);
        }

        [Authorize]
        [HttpDelete]
        public async Task<ActionResult<Address>> DeleteAddress(string id)
        {
            Address address = await _addressService.DeleteAddress(id);

            return CreatedAtAction(nameof(DeleteAddress), address);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<Address>> PutAddress(AddressDTO addressDTO, string id)
        {
            Address address = await _addressService.UpdateAddress(addressDTO, id);

            return CreatedAtAction(nameof(PutAddress), address);
        }
    }

}
