using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Library.ExtensionMethods;
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
            IList<Book> booksToBeBorrowed = librarySystem.AllRegisteredBooks.Where(b => b.NumberOfCopies > 0).ToList();

            string message;
            if (!booksToBeBorrowed.Any())
            {
                message = "No books registered. Please ask an Admin to add a book first!";
                ConsoleHelper.AwaitForAnyKeyPress(message);
                return;
            }

            message = "Select the book you want to borrow:";
            
            Book selectedBook = ConsoleHelper.MultipleChoicePrompter(booksToBeBorrowed, message);
            
            
            
            ++librarySystem.AllRegisteredBooks.First(registeredBook => registeredBook.Equals(selectedBook)).NumberOfBorrowedCopies;
            --librarySystem.AllRegisteredBooks.First(registeredBook => registeredBook.Equals(selectedBook)).NumberOfCopies;
            
            librarySystem.AllBorrowedBookForms.Add(new BorrowedBookForm(selectedBook));
        }
    }
}