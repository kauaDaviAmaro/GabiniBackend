using Core.Models;

namespace Core.Repositories
{
    public interface IUserRepository
    {
        public Task<User> SaveUser(User user);

        public Task<User> UpdateUser(User user);

        public Task<User?> GetUser(string id);
    }
}
