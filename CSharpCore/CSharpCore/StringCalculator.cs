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

            var numbersSplit = numbers.Split(new[] {',', '\n'}, StringSplitOptions.RemoveEmptyEntries);

            if (numbersSplit.Length == 1)
            {
                if (int.TryParse(numbersSplit[0], out var result))
                {
                    return result;
                } 
            }

            throw new ArgumentException("Invalid");
        }
    }
}