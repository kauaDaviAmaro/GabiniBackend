using Core.Models;
using Core.Repositories;
using Infrastructure.Repositories.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly GabiniDbContext _context;

        public AuthRepository(GabiniDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmailAndPassword(string email, string password)
        {
            return await _context.Users.FirstOrDefaultAsync(c => (c.Email == email || c.UserName == email) && c.Password == password);
        }
    }
}
