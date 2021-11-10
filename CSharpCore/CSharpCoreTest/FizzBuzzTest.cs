using FluentAssertions;
using Xunit;

namespace CSharpCore.Test
{
    public class FizzBuzzTest
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        public void ShouldAnswerWithNumber(int number, string expectedAnswer)
        {
            FizzBuzz.Answer(number).Should().Be(expectedAnswer);
        }
        
        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        public void ShouldAnswerWithFizz(int number)
        {
            FizzBuzz.Answer(number).Should().Be("Fizz");
        }
        
    }
}