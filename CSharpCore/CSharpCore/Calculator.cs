using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace CSharpCore
{
    public static class Calculator
    {
        private static readonly char[] DefaultDelimiters = new[] { ',', '\n' };

        public static int Add(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                return 0;
            }

            List<char> delimiters = new List<char>(DefaultDelimiters);

            if (input.StartsWith("//") && input[3] == '\n')
            {
                delimiters.Add(input[2]);
                input = input.Substring(input.IndexOf('\n'));
            }

            var numbers = input
                .Split(delimiters.ToArray())
                .Where(p => !String.IsNullOrEmpty(p));

            try
            {
                return numbers
                    .Select(p => int.Parse(p))
                    .Sum();
            }
            catch
            {
                throw new ArgumentException();
            }
        }
    }
}