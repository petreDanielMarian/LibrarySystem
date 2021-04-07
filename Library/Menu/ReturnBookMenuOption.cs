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
            if (!librarySystem.BorrowedBookForms.Any())
            {
                ConsoleHelper.AwaitForAnyKeyPress("No borrowed books!");
                return;
            }
            
            string message = "Choose a book to return:\n Borrow Date - Name - ISBN";
            BorrowedBookForm returnedBookForm = ConsoleHelper.MultipleChoicePrompter(librarySystem.BorrowedBookForms.OrderBy(bf => bf.BorrowDate).ToList(), message);

            ++librarySystem.RegisteredBooks.First(book => book.Equals(returnedBookForm.BorrowedBook)).NumberOfCopies;
            --librarySystem.RegisteredBooks.First(book => book.Equals(returnedBookForm.BorrowedBook)).NumberOfBorrowedCopies;
            
            returnedBookForm.CalculateDelayedReturnFee();
            message = returnedBookForm.GetDisplayMessageBasedOnTheFee();
            
            ConsoleHelper.AwaitForAnyKeyPress(message);

            //delete the form for this book
            librarySystem.BorrowedBookForms.RemoveFirst(form => form.Equals(returnedBookForm));

            message = $"Book titled {returnedBookForm.BorrowedBook.Name} was successfully returned!\nWe hope you had a blast!";
            ConsoleHelper.AwaitForAnyKeyPress(message);
        }
    }
}