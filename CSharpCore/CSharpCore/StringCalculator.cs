using System;

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

            if (int.TryParse(numbers, out var result))
            {
                return result;
            }

            throw new ArgumentException("Invalid");
        }
    }
}