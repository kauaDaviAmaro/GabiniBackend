using Core.Models;

namespace Core.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
