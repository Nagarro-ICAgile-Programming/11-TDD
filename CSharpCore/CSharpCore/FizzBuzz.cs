using System;

namespace CSharpCore
{
    public static class FizzBuzz
    {
        private const string fizz = "Fizz";
        private const string buzz = "Buzz";
        private const string fizzbuzz = "FizzBuzz";

        public static string Answer(int input)
        {
            if (input % 15 == 0)
            {
                return fizzbuzz;
            }
            if (input % 3 == 0)
            {
                return fizz;
            }
            if (input % 5 == 0)
            {
                return buzz;
            }

            return input.ToString();
        }
    }
}