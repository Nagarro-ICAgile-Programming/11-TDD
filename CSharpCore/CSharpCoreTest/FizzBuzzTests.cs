using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using Xunit;

namespace CSharpCore.Test
{
    public class FizzBuzzTests
    {
        [Fact]
        public void Answer_ReturnsNumber()
        {
            string result = FizzBuzz.Answer(1);

            result.Should().Be("1");
        }

        [Fact]
        public void Answer_ReturnsFizz_WhenDivisibleOnlyBy3()
        {
            string result = FizzBuzz.Answer(3);

            result.Should().Be("Fizz");
        }

        [Fact]
        public void Answer_ReturnsBuzz_WhenDivisibleOnlyBy5()
        {
            string result = FizzBuzz.Answer(5);

            result.Should().Be("Buzz");
        }

        [Fact]
        public void Answer_ReturnsFizzBuzz_WhenDivisibleBy3And5()
        {
            string result = FizzBuzz.Answer(15);

            result.Should().Be("FizzBuzz");
        }
    }
}
