using Core.Models;
using Core.Repositories;
using Core.Services;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> GetUserOrThrowException(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
