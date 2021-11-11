using System;
using FluentAssertions;
using Xunit;

namespace CSharpCore.Test
{
    public class PasswordTest
    {
        [Fact]
        public void Check_6chars_ReturnsTrue()
        {
            bool result = Password.Check("Abcd_9");

            result.Should().Be(true);
        }

        [Fact]
        public void Check_5chars_ReturnsFalse()
        {
            bool result = Password.Check("abcde");

            result.Should().Be(false);
        }

        [Fact]
        public void Check_13chars_ReturnsFalse()
        {
            bool result = Password.Check("abcdefghijklm");

            result.Should().Be(false);
        }

        [Fact]
        public void Check_6charsNoLowerCaseChars_ReturnsFalse()
        {
            bool result = Password.Check("ABCD_9");

            result.Should().Be(false);
        }

        [Fact]
        public void Check_6charsNoUpperCaseChars_ReturnsFalse()
        {
            bool result = Password.Check("abcd_9");

            result.Should().Be(false);
        }

        [Fact]
        public void Check_6charsNoNumberChars_ReturnsFalse()
        {
            bool result = Password.Check("Abcdef");

            result.Should().Be(false);
        }

        [Fact]
        public void Check_6charsNoSpecialChars_ReturnsFalse()
        {
            bool result = Password.Check("Abcde9");

            result.Should().Be(false);
        }
    }
}