using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpCore
{
    public class PasswordValidator
    {
        private static readonly List<char> specialCharacters = new List<char> { '_', '-', ',', '/' };

        public static bool Validate(string password)
        {
            return
                password.Length >= 6 &&
                password.Any(p => char.IsLower(p)) &&
                password.Any(p => char.IsUpper(p)) &&
                password.Any(p => char.IsDigit(p)) &&
                password.Any(p => specialCharacters.Contains(p)) &&
                password.Length <= 12;
        }
    }
}
