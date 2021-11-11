using FluentAssertions;
using Xunit;

namespace CSharpCore.Test
{
    public class PasswordValidatorTest
    {
        // • A password must be at least 6 characters long
        // • It must contain at least a lowercase character
        // • It must contain at least an uppercase character
        // • It must contain at least a number
        // • It must contain at least one: underscore, dash, comma or slash.
        // • It must be at most 12 characters long
        
        // "123" -> false // length
        // "1234567890aA_" -> false // length
        // "123aA_" -> true // underscore
        // "123aA-" -> true // dash
        // "123aA," -> true // comma
        // "123aA/" -> true // slash
        // "1234A_" -> false // no lowercase
        // "1234a_" -> false // no uppercase
        // "aA_aA_" -> false // no number
        
        [Theory]
        [InlineData("1234A_")]
        [InlineData("1234a_")]
        [InlineData("aA_aA_")]
        [InlineData("123")]
        [InlineData("1234567890aA_")]
        public void PasswordValidator_Validate_ShouldBeInvalid(string password)
        {
            var validator = new PasswordValidator();
            var result = validator.Validate(password);
            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("123aA_")]
        [InlineData("123aA-")]
        [InlineData("123aA,")]
        [InlineData("123aA/")]
        public void PasswordValidator_Validate_ShouldBeValid(string password)
        {
            var validator = new PasswordValidator();
            var result = validator.Validate(password);
            result.Should().BeTrue();
        }
    }
}