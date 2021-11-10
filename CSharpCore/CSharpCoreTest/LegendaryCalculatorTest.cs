using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
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

        [Fact]
        public void ShouldThrowArgumentException()
        {
            Action exceptionAdd = () => LegendaryCalculator.Add("Xd");
            exceptionAdd.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void ShouldAddNumbersWithCustomDelimiter()
        {
            LegendaryCalculator.Add("//|\n1|1\n1,1").Should().Be(4);
        }
    }
}
