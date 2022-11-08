
namespace CarDealer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Role { get; set; } = "User";
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; } = DateTime.Now;
        public DateTime TokenExpires { get; set; } = DateTime.Now;
        public User(string firstName, string lastName, string username, string email, byte[] passwordHash, byte[] passwordSalt)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
        public User(string role, string firstName, string lastName, string username, string email, byte[] passwordHash, byte[] passwordSalt)
        {
            Role = role;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
    }
}
