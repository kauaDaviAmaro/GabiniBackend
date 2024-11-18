using Core.DTOs;
using Core.Models;

namespace Core.Services
{
    public interface IUserService
    {
        public Task<User> GetUserById(string id);
        public Task<User> UpdateUser(string id, UserDTO userDTO);
        public Task<User> SaveUser(UserDTO userDTO);

        public Task<User> UpdatePassword(string userId, ChangePasswordDTO password);

        public Task<string> SaveProfilePicture(FileData fileData, string userId);
    }
}
