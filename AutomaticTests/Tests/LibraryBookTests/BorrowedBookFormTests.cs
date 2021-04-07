using System;
using FluentAssertions;
using Library;
using Library.LibraryBook;
using Xunit;

namespace AutomaticTests.Tests.LibraryBookTests
{
    public class BorrowedBookFormTests
    {
        private readonly BorrowedBookForm _borrowedBookForm;
        public BorrowedBookFormTests()
        {
            
            _borrowedBookForm = new BorrowedBookForm(new Book("some", "1234512345123", 2, 20));
        }

        [Fact]
        public void BorrowedBookFormShouldHaveZeroBookedCopies()
        {
            //Assert
            _borrowedBookForm.BorrowedBook.NumberOfBorrowedCopies.Should().Be(0);
        }

        [Fact]
        public void DelayedReturnFeeShouldBeCalculatedIfTwoWeeksAndFourDaysPassed()
        {
            //Arrange
            int fourDaysAfterTwoWeeks = LibraryApplicationConstants.TWO_WEEKS_IN_DAYS + 4;
            _borrowedBookForm.BorrowDate = DateTime.Today.AddDays(-fourDaysAfterTwoWeeks);
            
            //Act
            _borrowedBookForm.CalculateDelayedReturnFee();
            
            //Assert
            _borrowedBookForm.BookReturnedOnTime.Should().BeFalse();
            _borrowedBookForm.DelayedReturnFee.Should().Be(0.8); // 0.01 * 20 * 4
        }

        [Fact]
        public void DelayedReturnFeeShouldBeZeroIfBookWasReturnedOnTime()
        {
            //Arrange
            int twoWeeksWithoutFourDays = LibraryApplicationConstants.TWO_WEEKS_IN_DAYS - 4;
            _borrowedBookForm.BorrowDate = DateTime.Today.AddDays(-twoWeeksWithoutFourDays);
            
            //Act
            _borrowedBookForm.CalculateDelayedReturnFee();
            
            //Assert
            _borrowedBookForm.BookReturnedOnTime.Should().BeTrue();
            _borrowedBookForm.DelayedReturnFee.Should().Be(0.0);
        }

        [Fact]
        public void DelayedReturnMessageShouldBeGoodIfBookWasReturnedOnTime()
        {
            //Arrange
            int twoWeeksWithoutFourDays = LibraryApplicationConstants.TWO_WEEKS_IN_DAYS - 4;
            _borrowedBookForm.BorrowDate = DateTime.Today.AddDays(-twoWeeksWithoutFourDays);
            
            //Act
            string displayMessageBasedOnTheFee = _borrowedBookForm.GetDisplayMessageBasedOnTheFee();

            //Assert
            _borrowedBookForm.BookReturnedOnTime.Should().BeTrue();
            displayMessageBasedOnTheFee.Should().Be("Congrats! You returned the book on time!");
        }

        [Fact]
        public void DelayedReturnMessageShouldTellTheChargeTaxIfBookWasNotReturnedOnTime()
        {
            //Arrange
            int fourDaysAfterTwoWeeks = LibraryApplicationConstants.TWO_WEEKS_IN_DAYS + 4;
            _borrowedBookForm.BorrowDate = DateTime.Today.AddDays(-fourDaysAfterTwoWeeks);
            
            //Act
            string displayMessageBasedOnTheFee = _borrowedBookForm.GetDisplayMessageBasedOnTheFee();

            //Assert
            _borrowedBookForm.BookReturnedOnTime.Should().BeFalse();
            displayMessageBasedOnTheFee.Should().StartWith("Sorry, you'll be charged");
        }
    }
}