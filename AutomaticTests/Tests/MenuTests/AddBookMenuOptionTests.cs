using FluentAssertions;
using Library;
using Library.LibraryBook;
using Library.Menu;
using Xunit;

namespace AutomaticTests.Tests.MenuTests
{
    public class AddBookMenuOptionTests
    {
        private readonly AddBookMenuOption _addBookMenuOption;
        private readonly LibrarySystem _librarySystem;
        public AddBookMenuOptionTests()
        {
            _addBookMenuOption = new AddBookMenuOption();
            _librarySystem = LibrarySystem.Instance;
        }

        [Fact]
        public void ShouldReturnFalseIfTheBookIsNotFoundInTheLibrary()
        {
            //Act + Assert
            _addBookMenuOption.BookIsbnIsAlreadyInLibrary(_librarySystem, "1234567890123").Should().BeFalse();
        }

        [Fact]
        public void ShouldReturnTrueIfTheBookIsFoundInTheLibrary()
        {
            //Arrange
            _librarySystem.RegisteredBooks.Add(new Book("some", "1234567890123", 2, 20));
            //Act + Assert
            _addBookMenuOption.BookIsbnIsAlreadyInLibrary(_librarySystem, "1234567890123").Should().BeTrue();
        }
    }
}