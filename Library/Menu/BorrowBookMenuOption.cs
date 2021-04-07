using System.Collections.Generic;
using System.Linq;
using Library.LibraryBook;

namespace Library.Menu
{
    public class BorrowBookMenuOption : AbstractMenuOption
    {
        public override Permission Permission => Permission.User;
        
        public override string Name => "BorrowBookMenuOption";
        
        public override string Description => "Borrow a book from the library system";
        
        public override void Execute(LibrarySystem librarySystem)
        {
            IList<Book> booksToBeBorrowed = librarySystem.RegisteredBooks.Where(b => b.NumberOfCopies > 0).ToList();

            string message;
            if (!booksToBeBorrowed.Any())
            {
                message = "No books registered. Please ask an Admin to add a book first!";
                ConsoleHelper.AwaitForAnyKeyPress(message);
                return;
            }

            message = "Select the book you want to borrow:\n Name - ISBN";
            Book selectedBook = ConsoleHelper.MultipleChoicePrompter(booksToBeBorrowed, message);

            ++librarySystem.RegisteredBooks.First(registeredBook => registeredBook.Equals(selectedBook)).NumberOfBorrowedCopies;
            --librarySystem.RegisteredBooks.First(registeredBook => registeredBook.Equals(selectedBook)).NumberOfCopies;
            
            librarySystem.BorrowedBookForms.Add(new BorrowedBookForm(selectedBook));
        }
    }
}