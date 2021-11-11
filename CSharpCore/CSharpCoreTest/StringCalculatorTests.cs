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
    [ ] "1,2" => 3
    [ ] "1,2\n3" => 6
    [ ] "1,,2" => 3
    [ ] " 1,  34 " => 35
    [ ] "1, 2, a" => ArgumentException
    [ ] "//+\n 4+5+6" => 15
    [ ] "//+\n 4\n5,6" => 15
    [ ] "//0\n 4+5+6" => ArgumentException
    [ ] "//\n1" => ArgumentException
    [ ] "//*\n 4+5+6" => ArgumentException
    [ ] "//-\n 4-5-6" => 15

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

        [Fact]
        public void Add_Throw_WhenInputIsInvalid()
        {
            var stringCalculator = new StringCalculator();

            Action action = () => stringCalculator.Add("SomeThingInvalid");

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
    }
}