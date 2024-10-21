using Core.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs;
using System.Net;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(AddressDTO addressDTO)
        {
            Address address = await _addressService.SaveAddress(addressDTO);

            return CreatedAtAction(nameof(PostAddress), new { id = address.Id }, address);
        }
    }

}
