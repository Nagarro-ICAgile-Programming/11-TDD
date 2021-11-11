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

            var numbersSplit = numbers
                .Split(new[] { ',', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(number => !string.IsNullOrWhiteSpace(number))
                .ToList();

            if (!numbersSplit.Any())
            {
                return 0;
            }
            
            if (numbersSplit.Count == 1)
            {
                return int.TryParse(numbersSplit.FirstOrDefault()?.Trim(), out var result) ? result : throw new ArgumentException("Invalid");
            }

            throw new ArgumentException("Invalid");
        }
    }
}