using System;
using System.Collections.Generic;
using System.Linq;
using Library.LibraryBook;

namespace Library.Menu
{
    public class GetAvailableBooksMenuOption : AbstractMenuOption
    {
        public override Permission Permission => Permission.All;
        
        public override string Name => "GetNumberOfAvailableBooksMenuOption";
        
        public override string Description => "Get all the available (not borrowed) books from the library system";
        
        public override void Execute(LibrarySystem librarySystem)
        {
            IEnumerable<Book> availableBooks = librarySystem.RegisteredBooks.Where(book => book.NumberOfCopies > 0).OrderBy(b => b.Name).ToList();
            
            if (!availableBooks.Any())
            {
                ConsoleHelper.AwaitForAnyKeyPress(LibraryApplicationConstants.NO_BOOKS_REGISTERED);
                return;
            }
            
            Console.Clear();
            
            Console.WriteLine("Number of copies - Name - ISBN - Price");
            foreach (Book availableBook in availableBooks)
            {
                Console.WriteLine($"{availableBook.NumberOfCopies} copies - {availableBook.Name} - {availableBook.ISBN} - {availableBook.PriceOfReturnDelay} lei");
            }
            
            Console.WriteLine("\nPress any key to return to the previous menu...");
            Console.ReadKey();
        }
    }
}