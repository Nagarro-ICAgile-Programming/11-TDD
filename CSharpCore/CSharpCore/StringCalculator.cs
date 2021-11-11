using System;
using System.Linq;

namespace CSharpCore
{


    
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            return numbers
                .Split(new[] { ',', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(number => !string.IsNullOrWhiteSpace(number))
                .Select(numberString => int.TryParse(numberString.Trim(), out var result) ? result : throw new ArgumentException("Invalid"))
                .Sum();
        }
    }
}