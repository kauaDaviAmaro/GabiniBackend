using Core.DTOs;
using Core.Models;
using Core.Repositories;
using Core.Services;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IImageService _imageService;

        public UserService(IUserRepository userRepository, IImageService imageService)
        {
            _userRepository = userRepository;
            _imageService = imageService;
        }

        public async Task<User> SaveUser(UserDTO userDTO)
        {
            User user = new User(userDTO);
            return await _userRepository.SaveUser(user);
        }

        public async Task<User> UpdateUser(string id, UserDTO userDTO)
        {
            User? userFound = await GetUserById(id);

            if (userFound == null)
            {
                throw new Exception("User not found");
            }

            userFound.Update(userDTO);
            return await _userRepository.UpdateUser(userFound);
        }

        public async Task<User?> GetUserById(string id)
        {
            return await _userRepository.GetUser(id);
        }

        public async Task<string> SaveProfilePicture(FileData fileData, string userId)
        {
            User user = await GetUserById(userId);

            string uploadedFileUrl = await _imageService.UploadImage(fileData, "users", userId);

            user.ProfilePicture = uploadedFileUrl;

            await _userRepository.UpdateUser(user);

            return uploadedFileUrl;
        }

        public async Task<User> UpdatePassword(string userId, ChangePasswordDTO changePasswordDTO)
        {
            User? user = await GetUserById(userId);

            if (user == null || changePasswordDTO.password == "")
            {
                throw new Exception("Error");
            }

            user.Password = changePasswordDTO.password;

            await _userRepository.UpdateUser(user);

            return user;
        }
    }
}
