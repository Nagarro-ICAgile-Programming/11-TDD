using System;
using FluentAssertions;
using Xunit;

namespace CSharpCore.Test
{
    /* TODO list 
    [X] "" => 0
    [X] "2" => 2
    [X] "invalid" => ArgumentException
    [X] ",2" oder "2," => 2
    [X] ",\n" => 0
    [X] "1,2" => 3
    [X] "1,2\n3" => 6
    [X] "1,,2" => 3
    [X] " 1,  34 " => 35
    [X] "1, 2, a" => ArgumentException
    [X] "//+\n 4+5+6" => 15
    [X] "//+\n 4\n5,6" => 15
    [X] "//0\n 4+5+6" => ArgumentException
    [X] "//\n1" => ArgumentException
    [X] "//*\n 4+5+6" => ArgumentException
    [X] "//-\n 4-5-6" => 15
    */
    public class StringCalculatorTests
    {
        [Fact]
        public void Add_ShouldReturn0_WhenInputIsEmpty()
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("");

            result.Should().Be(0);
        }
        
        [Fact]
        public void Add_ShouldReturnInt_WhenInputIsSingleNumber()
        {
            var stringCalculator = new StringCalculator();

            var result = stringCalculator.Add("2");

            result.Should().Be(2);
        }

        [Theory]
        [InlineData("SomeThingInvalid")]
        [InlineData("1, 2, a")]
        public void Add_Throw_WhenInputIsInvalid(string invalidInput)
        {
            var stringCalculator = new StringCalculator();

            Action action = () => stringCalculator.Add(invalidInput);

            action.Should().ThrowExactly<ArgumentException>();
        }
        
        [Theory]
        [InlineData(", 2", 2)]
        [InlineData("3,", 3)]
        [InlineData("4\n", 4)]
        [InlineData("\n5", 5)]
        public void Add_ReturnResult_WhenInputNumberIsEmpty(string input, int expected)
        {
            var stringCalculator = new StringCalculator();
            
            var result = stringCalculator.Add(input);

            result.Should().Be(expected);
        }
        
        [Theory]
        [InlineData("\n,", 0)]
        [InlineData("\n ,", 0)]
        public void Add_ReturnResult_WhenInputNumberIsEmptySeperated(string input, int expected)
        {
            var stringCalculator = new StringCalculator();
            
            var result = stringCalculator.Add(input);

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("1,2", 3)]
        [InlineData("1,2\n3", 6)]
        [InlineData("1,,2", 3)]
        [InlineData("1,    34", 35)]
        public void Add_ReturnSum_WhenInputNumberConsistOfMultipleNumbers(string input, int expected)
        {
            var stringCalculator = new StringCalculator();
            
            var result = stringCalculator.Add(input);

            result.Should().Be(expected);
        }
        
        [Theory]
        [InlineData("//+\n 4+5+6", 15)]
        [InlineData("//+\n 4\n5,6", 15)]
        [InlineData("//-\n 4-5-6", 15)]
        public void Add_ReturnSum_WhenCustomerDelimiterIsProvided(string input, int expected)
        {
            var stringCalculator = new StringCalculator();
            
            var result = stringCalculator.Add(input);

            result.Should().Be(expected);
        }
        
        [Theory]
        [InlineData("//4\n 4,5,1")]
        [InlineData("//\n1")]
        [InlineData("//*\n 4+5+6")]
        public void Add_Throw_WhenInputDelimiterIsInvalid(string invalidInput)
        {
            var stringCalculator = new StringCalculator();

            Action action = () => stringCalculator.Add(invalidInput);

            action.Should().ThrowExactly<ArgumentException>();
        }

        [Theory]
        [InlineData("-5", "-5")]
        public void Add_Throw_WhenInputContainsNegativeNumber(string invalidInput, string expectedErrorMessage)
        {
            var stringCalculator = new StringCalculator();

            Action action = () => stringCalculator.Add(invalidInput);

            action.Should()
                .ThrowExactly<ArgumentException>()
                .And.Message.Contains(expectedErrorMessage);
        }
    }
}