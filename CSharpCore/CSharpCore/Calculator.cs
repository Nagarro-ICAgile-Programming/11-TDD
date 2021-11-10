using System;
using System.Linq;

namespace CSharpCore
{
    public static class Calculator
    {
        public static int Add(string input)
        {
            if (String.IsNullOrWhiteSpace(input))
            {
                return 0;
            }

            var numbers = input
                .Split(',', '\n')
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