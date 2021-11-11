using System.Linq;

namespace CSharpCore
{
    public static class PasswordManager
    {
        public static bool IsCompliant(string input)
        {
            if (input.Length < 6)
            {
                return false;
            }

            if (!input.Any(char.IsLower))
            {
                return false;
            }

            if (!input.Any(char.IsUpper))
            {
                return false;
            }

            if (!input.Any(char.IsNumber))
            {
                return false;
            }

            char[] specialCharacters = { '_', '-', ',', '/' };
            if (!input.Any(c => specialCharacters.Contains(c)))
            {
                return false;
            }
            
            return true;
        }
    }
}