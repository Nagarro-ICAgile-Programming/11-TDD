using System;

namespace CSharpCore
{
    public static class Calculator
    {
        public static int Add(string input)
        {
            var splitted = input.Split(',', '\n');
            var result = 0;
            foreach (var value in splitted)
            {
                if (value.Equals(string.Empty) || value.Equals(",") || value.Equals("\n"))
                {
                    continue;
                }

                if (!int.TryParse(value, out var parsedValue))
                {
                    throw new ArgumentException();
                }

                result += parsedValue;
            }

            return result;
        }
    }
}