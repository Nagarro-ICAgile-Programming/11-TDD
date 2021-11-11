using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCore
{
    public static class LegendaryCalculator
    {
        public static int Add(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            List<char> delimiters = new List<char> { '\n', ',' };

            if (input.StartsWith("//"))
            {
                if (input.Length < 4 || input[3] != '\n')
                {
                    throw OurGloriousException(input);
                }

                delimiters.Add(input[2]);
                input = input.Substring(4);
            }

            var stringNumbers = input.Split(delimiters.ToArray());

            var numbers = stringNumbers.Select(
                x => int.TryParse(x, out int number) ? number : throw OurGloriousException(input));

            var negativeNumbers = numbers.Where(x => x < 0).ToArray();

            if (negativeNumbers.Any())
            {
                throw new NegativeNumberException(negativeNumbers);
            }

            return numbers.Sum();
        }

        private static ArgumentException OurGloriousException(string input) => new ArgumentException($"{input} is a fucking mess");
    }
}