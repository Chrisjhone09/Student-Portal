using System.Text.RegularExpressions;

namespace server.Models
{
    public class LoginModel
    {
        public string CDKemail { get; set; }
        public string Password { get; set; }
        private static readonly string EmailPattern = @"^example@cdk\.edu\.ph$";

        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, EmailPattern);
        }
    }
}