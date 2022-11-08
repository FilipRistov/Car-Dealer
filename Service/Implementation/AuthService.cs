using CarDealer.Domain.Auth;
using CarDealer.Exceptions;
using CarDealer.Helpers;
using CarDealer.Models;
using CarDealer.Service.Abstraction;
using CarGarage.DataAccess;

namespace CarDealer.Service.Implementation
{

    public class AuthService : IAuthService
    {
        private readonly DataContext _db;
        private readonly IJwtToken _jwt;
        public AuthService(DataContext db, IJwtToken jwt)
        {
            _db = db;
            _jwt = jwt;
        }

        public Token Login(LoginDto req)
        {
            var user = _db.Users.FirstOrDefault(x => x.Username == req.Username || x.Email == req.Username);
            if (user == null || !PasswordHasher.VerifyPassword(req.Password,user.PasswordHash,user.PasswordSalt))
            {
                throw new UserException(400, "Wrong login credentials.");
            }
            Token token = _jwt.CreateToken(user);
            user.RefreshToken = token.RefreshToken;
            //_db.Update(user);
            _db.SaveChanges();
            return token;
        }

        public UserDto Register(RegisterDto req)
        {
            Validate.ValidateUser(req);
            if(_db.Users.Any(x => x.Username == req.Username) || _db.Users.Any(x => x.Email == req.Email))
            {
                throw new UserException(400, "Username/Email is already registered");
            }
            PasswordHasher.CreatePasswordHash(req.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new User(req.Role, req.FirstName, req.LastName, req.Username, req.Email, passwordHash, passwordSalt);
            _db.Users.Add(user);
            _db.SaveChanges();
            return new UserDto(req.FirstName, req.LastName, req.Username, req.Email);
        }
        public Token GetRefreshToken(string token)
        {
            var user = _db.Users.FirstOrDefault(x => x.RefreshToken == token);
            if(user == null)
            {
                throw new UserException(400, "Invalid Refresh Token");
            }
            Token newToken = _jwt.CreateToken(user);
            if (newToken == null)
            {
                throw new Exception("Something went wrong.");
            }
            user.RefreshToken = newToken.RefreshToken;
            _db.SaveChanges();
            return newToken;
        }
    }
}
