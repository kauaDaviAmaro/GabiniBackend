using Core.Models;
using Core.Repositories;
using Infrastructure.Repositories.Data;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly GabiniDbContext _context;

        public UserRepository(GabiniDbContext context)
        {
            _context = context;
        }

        public async Task<User> SaveUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
