using System;
using FluentAssertions;
using Xunit;

namespace CSharpCore.Test
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_Return0_WhenInputIsEmpty()
        {
            int result = Calculator.Add("");

            result.Should().Be(0);
        }

        [Fact]
        public void Add_ReturnInput_WhenInputIsNumber()
        {
            int result = Calculator.Add("1");

            result.Should().Be(1);
        }

        [Fact]
        public void Add_ThrowArgumentException_WhenInputInvalid()
        {
            Action action = new Action(() => Calculator.Add("invalid"));

            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Add_Return0_WhenInputContainsEmptyDelimiter()
        {
            int result = Calculator.Add(",");

            result.Should().Be(0);
        }

        [Fact]
        public void Add_Return0_WhenInputContainsMultipleEmptyDelimiter()
        {
            int result = Calculator.Add(",\n");

            result.Should().Be(0);
        }

        [Fact]
        public void Add_ReturnSum_WhenInputContainsEmptyDelimiterAndNumber()
        {
            int result = Calculator.Add(",2");

            result.Should().Be(2);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("1,2\n3", 6)]
        [InlineData("1,\n,2", 3)]
        [InlineData(" 1,  2", 3)]
        public void Add_ReturnsSum_WhenInputIsValidCalculation(string input, int expectedResult)
        {
            int result = Calculator.Add(input);

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void Add_ThrowsArgumentException_WhenInputContainsInvalidData()
        {
            Action action = new Action(() => Calculator.Add("1,2,a"));

            action.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("//+\n 4+5+6", 15)]
        [InlineData("//+\n 4\n5,6", 15)]
        [InlineData("//-\n 4-5-6", 15)]
        public void Add_ReturnsSum_WhenNewDelimiterIsAdded(string input, int expectedResult)
        {
            int result = Calculator.Add(input);

            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("//0\n 4+5+6")]
        [InlineData("//\n 1")]
        public void Add_ThrowsArgumentException_WhenDelimiterIsInvalid(string input)
        {
            Action action = new Action(() => Calculator.Add(input));

            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void Add_ThrowsArgumentException_WhenWrongDelimiterIsUsed()
        {
            Action action = new Action(() => Calculator.Add("//*\n 4+5+6"));

            action.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData("-1", new int[] { -1 })]
        [InlineData("-1,5\n-10", new int[] { -1, -10 })]
        public void Add_ThrowsNegativeNumberException_WhenInputContainsNegativeNumber(string input, int[] expectedResult)
        {
            Action action = new Action(() => Calculator.Add(input));

            action.Should().Throw<NegativeNumberException>().Which.NegativeNumbers.Should().BeEquivalentTo(expectedResult);
        }
    }
}



/* TODO list 

[X] "" => 0
[X] "2" => 2
[X] "invalid" => ArgumentException
[X] "," => 0

BREAKING CHANGE
[X] ",\n" => 0
[X] ",2" oder "2," => 2
[X] "1,2" => 3
[X] "1,2\n3" => 6
[X] "1,,2" => 3
[X] " 1,  34 " => 35
[X] "1, 2, a" => ArgumentException

BREAKING CHANGE
[X] "//+\n 4+5+6" => 15
[X] "//+\n 4\n5,6" => 15
[X] "//0\n 4+5+6" => ArgumentException
[X] "//\n1" => ArgumentException
[X] "//*\n 4+5+6" => ArgumentException
[X] "//-\n 4-5-6" => 15

[X] "-1" => NegativeNumberException { -1 }
[X] "-1,5\n-10" => NegativeNumberException { -1, -10 }

*/
