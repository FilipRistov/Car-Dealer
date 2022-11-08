using CarDealer.Domain.Auth;
using CarDealer.Models;

namespace CarDealer.Service.Abstraction
{
    public interface IAuthService
    {
        UserDto Register(RegisterDto req);
        Token Login(LoginDto req);
        Token GetRefreshToken(string token);
    }
}
