using FluentAssertions;
using Library.ExtensionMethods;
using Xunit;

namespace AutomaticTests.Tests.ExtensionsMethodsTests
{
    public class StringExtensionsTests
    {
        private readonly string _stringWithNumbers;
        private readonly string _stringWithoutNumbers;
        public StringExtensionsTests()
        {
            _stringWithNumbers = "123";
            _stringWithoutNumbers = "ab12";
        }

        [Fact]
        public void ShouldReturnTrueIfStringHasOnlyNumbers()
        {
            //Act + Assert
            _stringWithNumbers.HasOnlyNumbers().Should().BeTrue();
        }

        [Fact]
        public void ShouldReturnFalseIfStringHasAllSortsOfCharacters()
        {
            //Act + Assert
            _stringWithoutNumbers.HasOnlyNumbers().Should().BeFalse();
        }
    }
}