using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCore
{
    public static class Calculator
    {
        public static int Add(string input)
        {
            var delimiters = new List<char>();
            (input, delimiters) = ParseDelimiter(input);

            var splitted = input.Split(delimiters.ToArray());
            var result = 0;
            var negativeNumbers = new List<int>();

            foreach (var value in splitted)
            {
                if (value.Equals(string.Empty))
                {
                    continue;
                }

                if (!int.TryParse(value, out var parsedValue))
                {
                    throw new ArgumentException();
                }

                if (parsedValue < 0)
                {
                    negativeNumbers.Add(parsedValue);
                }

                result += parsedValue;
            }

            if (negativeNumbers.Any())
            {
                throw new NegativeNumberException(negativeNumbers);
            }

            return result;
        }

        private static (string, List<char>) ParseDelimiter(string input)
        {
            var delimiters = new List<char> { ',', '\n' };

            if (input.StartsWith("//") && input[3].Equals('\n'))
            {
                var delimiter = input[2];

                if (char.IsNumber(delimiter))
                {
                    throw new ArgumentException();
                }

                delimiters.Add(delimiter);
                return (input[4..], delimiters);
            }

            return (input, delimiters);
        }
    }
}