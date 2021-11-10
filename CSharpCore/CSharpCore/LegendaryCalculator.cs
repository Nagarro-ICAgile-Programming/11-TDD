using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCore
{
    public static class LegendaryCalculator
    {
        public static int Add(string input)
        {
            try
            {
                List<char> delimiters = new List<char> { '\n', ',' };

                if (string.IsNullOrEmpty(input))
                {
                    return 0;
                }
                if (input.StartsWith("//") && input[3] == '\n')
                {
                    delimiters.Add(input[2]);
                    input = input.Substring(4);
                }
                var stringNumbers = input.Split(delimiters.ToArray());
                return Array.ConvertAll(stringNumbers, int.Parse).Sum();
            }
            catch
            {
                throw new ArgumentException($"{input} is a fucking mess");
            }
                                    
        }
    }
}