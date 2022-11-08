using CarDealer.Models;
using System.Security.Claims;

namespace CarDealer.Helpers
{
    public interface IJwtToken
    {
        Token CreateToken(User user);
        string GenerateRefreshToken();
    }
}
