using System;

namespace CSharpCore
{
    public static class Calculator
    {
        public static int Add(string input)
        {
            if (input.Equals(string.Empty) || input.Equals(","))
            {
                return 0;
            }
            if (!int.TryParse(input, out var result))
            {
                throw new ArgumentException();
            }

            return result;
        }
    }
}