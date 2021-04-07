using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Library;
using Library.Menu;
using Xunit;

namespace AutomaticTests.Tests.MenuTests
{
    public class MenuOptionsTests
    {
        private readonly AddBookMenuOption _addBookMenuOption;
        private readonly LibrarySystem _librarySystem;
        public MenuOptionsTests()
        {
            _addBookMenuOption = new AddBookMenuOption();
            _librarySystem = LibrarySystem.Instance;
        }

        [Fact]
        public void ShouldShowOnlyTheMenuOptionsForAllAndTheUserIfTheAccountIsTheUser()
        {
            //Arrange
            LibraryApplication.SelectedUser = Permission.User;

            //Act
            IList<IMenuOption> userMenuOptions = MenuOptionsDefinitions.MenuOptions.
                Where(mo => (mo.Permission & LibraryApplication.SelectedUser) == LibraryApplication.SelectedUser).
                ToList();

            //Assert
            userMenuOptions.Should().ContainInOrder(new List<IMenuOption> {
                MenuOptionsDefinitions.BorrowBook,
                MenuOptionsDefinitions.ReturnBook,
                MenuOptionsDefinitions.NumberOfAvailableBooks,
                MenuOptionsDefinitions.NumberOfCopies,
                MenuOptionsDefinitions.SwitchUsers,
                MenuOptionsDefinitions.Exit
            });
        }

        [Fact]
        public void ShouldShowOnlyTheMenuOptionsForAllAndTheAdminIfTheAccountIsTheAdmin()
        {
            //Arrange
            LibraryApplication.SelectedUser = Permission.Admin;

            //Act
            IList<IMenuOption> userMenuOptions = MenuOptionsDefinitions.MenuOptions.
                Where(mo => (mo.Permission & LibraryApplication.SelectedUser) == LibraryApplication.SelectedUser).
                ToList();

            //Assert
            userMenuOptions.Should().ContainInOrder(new List<IMenuOption> {
                MenuOptionsDefinitions.AddBook,
                MenuOptionsDefinitions.NumberOfAvailableBooks,
                MenuOptionsDefinitions.NumberOfCopies,
                MenuOptionsDefinitions.SwitchUsers,
                MenuOptionsDefinitions.Exit
            });
        }
    }
}