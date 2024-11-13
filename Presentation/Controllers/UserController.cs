using Core.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class ClienteController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IAuthService _authService;

        public ClienteController(IUserService UserService, IAuthService AuthService)
        {
            _authService = AuthService;
            _userService = UserService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDTO userDTO)
        {
            User user = await _userService.SaveUser(userDTO);

            return CreatedAtAction(nameof(PostUser), new { id = user.Id }, user);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult<User>> PutUser(UserDTO userDTO)
        {
            string userId = _authService.GetAuthenticatedUserId(User);
            User user = await _userService.UpdateUser(userId, userDTO);

            return AcceptedAtAction(nameof(PutUser), new { id = user.Id }, user);
        }

        [Authorize]
        [HttpPut("password")]
        public async Task<ActionResult<User>> PutUser(ChangePasswordDTO passwordDTO)
        {
            string userId = _authService.GetAuthenticatedUserId(User);
            User user = await _userService.UpdatePassword(userId, passwordDTO);

            return user;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<User>> GetUser()
        {
            string userId = _authService.GetAuthenticatedUserId(User);

            User user = await _userService.GetUserById(userId);

            return AcceptedAtAction(nameof(GetUser), user);
        }

        [Authorize]
        [HttpPost("profilePicture")]
        public async Task<ActionResult<String>> PostProfilePicture(IFormFile profilePicture)
        {
            if (profilePicture == null || profilePicture.Length == 0)
            {
                return BadRequest("No image found");
            }

            using var memoryStream = new MemoryStream();
            await profilePicture.CopyToAsync(memoryStream);

            FileData fileData = new FileData
            {
                FileName = profilePicture.FileName,
                Content = memoryStream.ToArray(),
                ContentType = profilePicture.ContentType,
                Extension = Path.GetExtension(profilePicture.FileName),
            };

            string userId = _authService.GetAuthenticatedUserId(User);
            string imageUrl = await _userService.SaveProfilePicture(fileData, userId);

            return CreatedAtAction(nameof(PostProfilePicture), imageUrl);
        }
    }

}
