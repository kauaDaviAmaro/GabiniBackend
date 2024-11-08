using Core.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService UserService)
        {
            _userService = UserService;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDTO userDTO)
        {
            User user = await _userService.SaveUser(userDTO);

            return CreatedAtAction(nameof(PostUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutUser(string id, UserDTO userDTO)
        {
            User user = await _userService.UpdateUser(id, userDTO);

            return AcceptedAtAction(nameof(PutUser), new { id = user.Id }, user);
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
