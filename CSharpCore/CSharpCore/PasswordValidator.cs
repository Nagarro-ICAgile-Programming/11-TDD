using System.Linq;

namespace CSharpCore
{
    public class PasswordValidator
    {
        private static char[] specialCharacters = new char[] { '_', '-', ',', '/' };

        public bool Validate(string password)
        {
            if (password.Length < 6 || password.Length > 12)
                return false;

            if (!password.Any(char.IsLower) || !password.Any(char.IsUpper) || !password.Any(char.IsDigit))
                return false;

            return password.Any(c => specialCharacters.Contains(c));
        }
    }
}