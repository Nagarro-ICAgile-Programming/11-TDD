using FluentAssertions;
using Xunit;

namespace CSharpCore.Test
{
    public class PasswordComplianceTests
    {   
        [Fact]
        public void IsCompliant_ShouldReturnTrue_WhenValidPasswordIsProvided()
        {
            bool isCompliant = PasswordManager.IsCompliant("A1_fgh");

            isCompliant.Should().BeTrue();
        }
        
        [Fact]
        public void IsCompliant_ShouldReturnFalse_WhenInputLengthIsLessThan6()
        {
            bool isCompliant = PasswordManager.IsCompliant("");
        
            isCompliant.Should().BeFalse();
        }
        
        [Fact]
        public void IsCompliant_ShouldReturnFalse_WhenInputHasNoLowerCharacter()
        {
            bool isCompliant = PasswordManager.IsCompliant("A1!FGH");
        
            isCompliant.Should().BeFalse();
        }
        
        [Fact]
        public void IsCompliant_ShouldReturnFalse_WhenInputHasNoUpperCharacter()
        {
            bool isCompliant = PasswordManager.IsCompliant("a1!fgh");
        
            isCompliant.Should().BeFalse();
        }
        
        [Fact]
        public void IsCompliant_ShouldReturnFalse_WhenInputHasNoNumber()
        {
            bool isCompliant = PasswordManager.IsCompliant("AB!fgh");
        
            isCompliant.Should().BeFalse();
        }
        
        [Fact]
        public void IsCompliant_ShouldReturnFalse_WhenInputHasNoSpecialCharacter()
        {
            bool isCompliant = PasswordManager.IsCompliant("AB1fgh");
        
            isCompliant.Should().BeFalse();
        }
        
        [Fact]
        public void IsCompliant_ShouldReturnFalse_WhenInputHasMoreThan12Characters()
        {
            bool isCompliant = PasswordManager.IsCompliant("AB1fghasdfasd");
        
            isCompliant.Should().BeFalse();
        }
    }
}

/*
bool IsPasswordCompliant(string)

"" => false
"asdfgh" => true

*/