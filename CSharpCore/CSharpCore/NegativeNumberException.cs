using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCore
{
    public class NegativeNumberException : Exception
    {
        public List<string> Numbers { get; }

        public NegativeNumberException(string[] numbers) : base("Negative numbers are not allowed")
        {
            this.Numbers = numbers.ToList();
        }
    }
}
