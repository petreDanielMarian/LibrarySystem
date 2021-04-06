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
            IEnumerable<Book> availableBooks = librarySystem.AllRegisteredBooks.Where(book => book.NumberOfCopies > 0).ToList();
            
            if (!availableBooks.Any())
            {
                ConsoleHelper.AwaitForAnyKeyPress("No books registered!");
                return;
            }
            
            Console.Clear();
            
            Console.WriteLine("Number of copies - Name\t: ISBN");
            foreach (Book availableBook in availableBooks)
            {
                Console.WriteLine($"{availableBook.NumberOfCopies}\t\t- {availableBook.Name}\t: {availableBook.ISBN}");
            }
            
            Console.WriteLine("\nPress any key to return to the previous menu...");
            Console.ReadKey();
        }
    }
}