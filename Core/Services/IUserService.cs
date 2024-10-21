using Core.DTOs;
using Core.Models;

namespace Core.Services
{
    public interface IUserService
    {
        public Task<User> GetUserOrThrowException(string userId);
        public Task<User> SaveUser(UserDTO userDTO);
    }
}
