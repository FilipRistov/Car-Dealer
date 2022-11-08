using CarDealer.Models;
using System.Security.Claims;

namespace CarDealer.Helpers
{
    public interface IJwtToken
    {
        ClaimsPrincipal GetPrincipal(string token);
        Token CreateToken(User user);
        string GenerateRefreshToken();
    }
}
