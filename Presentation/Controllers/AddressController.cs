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
    }

}
