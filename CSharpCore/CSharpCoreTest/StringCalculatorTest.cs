using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace CSharpCore.Test
{
    public class StringCalculatorTest
    {
        [Fact]
        public void ShouldReturnZeroIfEmpty()
        {
            StringCalculator.Add(string.Empty).Should().Be(0);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("2", 2)]
        public void ShouldReturnStringAsNumber(string input, int expectedNumber)
        {
            StringCalculator.Add(input).Should().Be(expectedNumber);
        }

        [Theory]
        [InlineData("1\n2", 3)]
        [InlineData("1\n2,3", 6)]
        public void ShouldSumStringWithDelimiter(string input, int expectedNumber)
        {
            StringCalculator.Add(input).Should().Be(expectedNumber);
        }

        [Theory]
        [InlineData(" 2, 5", 7)]
        public void ShouldIgnoreWidespaces(string input, int expectedNumber)
        {
            StringCalculator.Add(input).Should().Be(expectedNumber);
        }

        [Theory]
        [InlineData("//+\n 3+4", 7)]
        public void ShouldUseCustomDelimiter(string input, int expectedNumber)
        {
            StringCalculator.Add(input).Should().Be(expectedNumber);
        }

        [Theory]
        [InlineData("-1", new string[] {"-1"})]
        [InlineData("-1, -7", new string[] { "-1", " -7" })]
        //[InlineData("1, -7, 6")]
        public void ShouldThrowException(string input, string[] errorNumbers)
        {
            Action action = () => StringCalculator.Add(input);
            action.Should()
                .Throw<NegativeNumberException>()
                .WithMessage("Negative numbers are not allowed")
                .Where(ex => errorNumbers.SequenceEqual(ex.Numbers));
        }
    }
}
