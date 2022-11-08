using CarDealer.Domain.Auth;
using CarDealer.Exceptions;
using CarGarage.DataAccess;
using System.Text.RegularExpressions;

namespace CarDealer.Helpers
{
    public class Validate
    {

        public static bool IsUsernameValid(string username)
        {
            var usernameRegex = new Regex(@"^[A-z][A-z0-9-_]{5,24}$");
            var match = usernameRegex.Match(username);
            return match.Success;
        }

        public static bool IsEmailValid(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            return match.Success;
        }

        public static bool IsPasswordValid(string password)
        {
            var passwordRegex = new Regex("^(?=.*[0-9])(?=.*[a-z]).{8,20}$");
            var match = passwordRegex.Match(password);
            return match.Success;
        }
        public static void ValidateUser(RegisterDto user)
        {
            if (string.IsNullOrEmpty(user.FirstName))
            {
                throw new UserException(400, "First name is required.");
            }
            if (string.IsNullOrEmpty(user.LastName))
            {
                throw new UserException(400, "Last name is required.");
            }
            if (string.IsNullOrEmpty(user.Username))
            {
                throw new UserException(400, "Username is required.");
            }
            if (!IsUsernameValid(user.Username))
            {
                throw new UserException(400, "Please enter a valid username");
            }
            if (string.IsNullOrEmpty(user.Email))
            {
                throw new UserException(400, "Email is required.");
            }
            if (!IsEmailValid(user.Email))
            {
                throw new UserException(400, "Please enter a valid email format.");
            }
            if (string.IsNullOrEmpty(user.Password))
            {
                throw new UserException(400, "Password cannot be empty");
            }
            if (user.Password != user.ConfirmPassword)
            {
                throw new UserException(400, "Passwords do not match");
            }
            if (!IsPasswordValid(user.Password))
            {
                throw new UserException(400, "Please enter a valid password format");
            }
        }
    }
}
