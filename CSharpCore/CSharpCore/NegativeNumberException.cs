using System;

namespace CSharpCore
{
    public class NegativeNumberException : Exception
    {
        public NegativeNumberException(int[] numbers)
        {
            this.Numbers = numbers;
        }

        public int[] Numbers { get; }
    }
}