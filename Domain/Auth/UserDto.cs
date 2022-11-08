namespace CarDealer.Domain.Auth
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public UserDto(string firstName, string lastName, string username, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
        }
        public UserDto(string firstName, string lastName, string username, string email, string token)
        {
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Email = email;
            Token = token;
        }
    }
}
