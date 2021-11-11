using System;
using System.Collections.Generic;

namespace CSharpCore
{
    public class NegativeNumberException : Exception
    {
        public List<int> NegativeNumbers { get; internal set; } = new List<int>();

        public NegativeNumberException(List<int> negativeNumbers)
        {
            this.NegativeNumbers = negativeNumbers;
        }
    }
}