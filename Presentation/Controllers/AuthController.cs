using Application.Services;
using Core.DTOs;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("signIn")]
        public async Task<ActionResult<string>> SignIn(SignInCustomerDTO signInCustomerDTO)
        {
            try
            {
                string token = await _authService.SignIn(signInCustomerDTO.Email, signInCustomerDTO.Password);
                return CreatedAtAction(nameof(SignIn), token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
