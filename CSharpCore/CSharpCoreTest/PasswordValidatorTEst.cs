using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CSharpCore.Test
{
    public class PasswordValidatorTest
    {
        [Theory]
        [InlineData("aA123456_")]
        [InlineData("aA123456-")]
        [InlineData("aA123456,")]
        [InlineData("aA123456/")]
        public void ShouldBeValid(string password)
        {
            PasswordValidator.Validate(password).Should().BeTrue();
        }

        [Theory]
        [InlineData("aA1_")]
        public void ShouldContainAtLeast6Characters(string password)
        {
            PasswordValidator.Validate(password).Should().BeFalse();
        }

        [Theory]
        [InlineData("A123456_")]
        public void ShouldContainAtLeast1LowercaseCharacter(string password)
        {
            PasswordValidator.Validate(password).Should().BeFalse();
        }

        [Theory]
        [InlineData("a123456_")]
        public void ShouldContainAtLeast1UppercaseCharacter(string password)
        {
            PasswordValidator.Validate(password).Should().BeFalse();
        }

        [Theory]
        [InlineData("aAaaa_")]
        public void ShouldContainAtLeast1Number(string password)
        {
            PasswordValidator.Validate(password).Should().BeFalse();
        }

        [Theory]
        [InlineData("aA123456")]
        public void ShouldContainAtLeast1UnderscoreDashCommaOrSlash(string password)
        {
            PasswordValidator.Validate(password).Should().BeFalse();
        }

        [Theory]
        [InlineData("aA0123456789_")]
        public void ShouldContainAtMost12Characters(string password)
        {
            PasswordValidator.Validate(password).Should().BeFalse();
        }
    }
}

