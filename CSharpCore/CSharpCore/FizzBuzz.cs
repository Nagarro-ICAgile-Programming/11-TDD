namespace CSharpCore
{
    public static class FizzBuzz
    {
        public static string Answer(int number)
        {
            if (number % 3 == 0) return "Fizz";
            return number.ToString();
        }
    }
}