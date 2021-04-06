using System;
using System.Collections.Generic;
using System.Linq;
using Library.ExtensionMethods;
using Library.LibraryBook;

namespace Library.Menu
{
    public class ReturnBookMenuOption : AbstractMenuOption
    {
        public override Permission Permission => Permission.User;
        
        public override string Name => "ReturnBookMenuOption";
        
        public override string Description => "Return a borrowed book back to the library system";
        
        public override void Execute(LibrarySystem librarySystem)
        {
            if (!librarySystem.AllBorrowedBookForms.Any())
            {
                ConsoleHelper.AwaitForAnyKeyPress("No borrowed books!");
                return;
            }
            
            string message = "Choose a book to return:";
            BorrowedBookForm returnedBookForm = ConsoleHelper.MultipleChoicePrompter(librarySystem.AllBorrowedBookForms, message);

            ++librarySystem.AllRegisteredBooks.First(book => book.Equals(returnedBookForm.BorrowedBook)).NumberOfCopies;
            --librarySystem.AllRegisteredBooks.First(book => book.Equals(returnedBookForm.BorrowedBook)).NumberOfBorrowedCopies;
            
            returnedBookForm.CalculateDelayedReturnFee();
            message = returnedBookForm.GetDisplayMessageBasedOnTheFee();
            
            ConsoleHelper.AwaitForAnyKeyPress(message);

            librarySystem.AllBorrowedBookForms.RemoveFirst(form => form.Equals(returnedBookForm));

            message = $"\nBook titled {returnedBookForm.BorrowedBook.Name} was successfully returned!\nWe hope you had a blast!";
            ConsoleHelper.AwaitForAnyKeyPress(message);
        }
    }
}