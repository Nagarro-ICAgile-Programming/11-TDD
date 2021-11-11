using System.Linq;

namespace CSharpCore
{
    public class Password
    {
        public static bool Check(string input)
        {
            return input.Length >= 6 &&
                   input.Length <= 12 &&
                   input.Any(char.IsLower) &&
                   input.Any(char.IsUpper) &&
                   input.Any(char.IsDigit) &&
                   input.Any(c => c == '_' ||
                                  c == '-' ||
                                  c == ',' ||
                                  c == '/');
        }
    }
}