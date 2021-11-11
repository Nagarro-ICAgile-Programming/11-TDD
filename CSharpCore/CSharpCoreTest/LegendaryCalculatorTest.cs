using FluentAssertions;
using System;
using System.Linq;
using Xunit;

namespace CSharpCore.Test
{
    public class LegendaryCalculatorTest
    {
        [Fact]
        public void ShouldReturnZeroFromEmptyString()
        {
            LegendaryCalculator.Add(string.Empty).Should().Be(0);
        }

        [Fact]
        public void ShouldReturOneNumberFromOneNumberString()
        {
            LegendaryCalculator.Add("1").Should().Be(1);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("1\n2", 3)]
        [InlineData("1\n2,3", 6)]
        [InlineData("1 \n 2 , 3", 6)]
        public void ShouldAddNumbersWithSpecifiedDelimiters(string inputString, int resultNumber)
        {
            LegendaryCalculator.Add(inputString).Should().Be(resultNumber);
        }

        [Theory]
        [InlineData("Xd")]
        [InlineData("//")]
        public void ShouldThrowArgumentException(string input)
        {
            Action exceptionAdd = () => LegendaryCalculator.Add(input);
            exceptionAdd.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("//|\n1|1\n1,1", 4)]
        [InlineData("//-\n1-1\n1-1", 4)]
        public void ShouldAddNumbersWithCustomDelimiter(string input, int expected)
        {
            LegendaryCalculator.Add(input).Should().Be(expected);
        }

        [Theory]
        [InlineData("-1", new int[] { -1 })]
        [InlineData("-1, -7", new int[] { -1, -7 })]
        [InlineData("1, -7, 6", new int[] { -7 })]
        public void ShouldThrowNegativeNumberExceptionForNegativeNumbers(string input, int[] expected)
        {
            Action exceptionAdd = () => LegendaryCalculator.Add(input);
            exceptionAdd.Should().Throw<NegativeNumberException>().Where(e => Enumerable.SequenceEqual(e.Numbers, expected));
        }


    }
}
