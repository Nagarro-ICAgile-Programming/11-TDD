using System;
using System.Collections.Generic;
using System.Text;
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
    }
}


/* TODO list 

[X] "" => 0
[X] "2" => 2
[X] "invalid" => ArgumentException
[X] "," => 0
[X] ",\n" => 0
[ ] ",2" oder "2," => 2
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
