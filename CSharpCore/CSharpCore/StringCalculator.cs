using System;
using System.Linq;

namespace CSharpCore
{
    public static class StringCalculator
    {
        private static char[] delimiter = new char[] { '\n', ',' };

        public static int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            input = ReplaceCustomDelimiter(input);

            string[] numbers = input.Split(delimiter);

            if (input.Contains('-'))
            {
                throw new NegativeNumberException(numbers);
            }

            return numbers.Aggregate(0, (sum, i) =>
                {
                    int.TryParse(i, out var result);
                    return sum + result;
                });
        }

        private static string ReplaceCustomDelimiter(string input)
        {
            if (input.StartsWith("//"))
            {
                char customDelimiter = input[2];
                input = input.Replace(customDelimiter, delimiter[0]);
            }

            return input;
        }
    }
}