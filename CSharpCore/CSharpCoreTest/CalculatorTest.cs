using System;
using FluentAssertions;
using Xunit;

namespace CSharpCore.Test
{
    public class CalculatorTest
    {
        [Fact]
        public void Add_EmptyString_Returns0()
        {
            int result = Calculator.Add("");

            result.Should().Be(0);
        }

        [Fact]
        public void Add_2_Returns2()
        {
            int result = Calculator.Add("2");

            result.Should().Be(2);
        }

        [Fact]
        public void Add_Invalid_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Calculator.Add("Invalid"));
        }

        [Fact]
        public void Add_1Comma2_Returns3()
        {
            int result = Calculator.Add("1,2");

            result.Should().Be(3);
        }

        [Fact]
        public void Add_1CarriageReturn2_Returns3()
        {
            int result = Calculator.Add("1\n2");

            result.Should().Be(3);
        }

        [Fact]
        public void Add_Comma2_Returns2()
        {
            int result = Calculator.Add(",2");

            result.Should().Be(2);
        }

        [Fact]
        public void Add_CommaCarriageReturn_Returns0()
        {
            int result = Calculator.Add(",\n");

            result.Should().Be(0);
        }

        [Fact]
        public void Add_1Comma2CarriageReturn3_Returns6()
        {
            int result = Calculator.Add("1,2\n3");

            result.Should().Be(6);
        }

        [Fact]
        public void Add_Space1CommaSpaceSpace34Space_Returns35()
        {
            int result = Calculator.Add(" 1,  34 ");

            result.Should().Be(35);
        }

        [Fact]
        public void Add_1Comma2CommaA_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Calculator.Add("1,2,a"));
        }
    }
}