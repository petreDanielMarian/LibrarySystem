using System;
using System.Linq;
using Library.ExtensionMethods;
using Library.LibraryBook;
using static System.String;

namespace Library.Menu
{
    public class AddBookMenuOption : AbstractMenuOption
    {
        public override Permission Permission => Permission.Admin;
        
        public override string Name => "AddBookMenuOption";
        
        public override string Description => "Add a new book to the library system";

        public override void Execute(LibrarySystem librarySystem)
        {
            Console.Clear();
            
            Console.WriteLine(LibraryApplicationConstants.ASK_BOOK_NAME);
            string bookName = GetNotNullOrEmptyStringFromInput();
            
            Console.WriteLine(LibraryApplicationConstants.ASK_BOOK_ISBN);
            string bookIsbn = GetValidIsbnNumberFromInput();
            
            Console.WriteLine(LibraryApplicationConstants.ASK_BOOK_NO_OF_COPIES);
            int numberOfCopies = GetNumericalValueFromInput();

            Console.WriteLine(LibraryApplicationConstants.ASK_BOOK_PRICE);
            int delayedReturnPrice = GetNumericalValueFromInput();

            if (BookIsbnIsAlreadyInLibrary(librarySystem, bookIsbn))
            {
                string message = $"Book with the same ISBN \"{bookIsbn}\" already exists!\nThe book was not registered, please try again!";
                ConsoleHelper.AwaitForAnyKeyPress(message);
                return;
            }
            
            librarySystem.RegisteredBooks.Add(new Book(bookName, bookIsbn, numberOfCopies, delayedReturnPrice));
            
            ConsoleHelper.AwaitForAnyKeyPress("Book added!");
        }

        private static string GetNotNullOrEmptyStringFromInput()
        {
            string value;
            while (true)
            {
                value = Console.ReadLine();

                if (!IsNullOrEmpty(value))
                {
                    break;
                }
                
                Console.WriteLine("Please enter a non-empty value!");
            }

            return value;
        }
        
        private static int GetNumericalValueFromInput()
        {
            int value;
            while (true)
            {
                bool valueIsParsed = int.TryParse(Console.ReadLine(), out value);

                if (valueIsParsed)
                {
                    break;
                }
                
                Console.WriteLine("Please enter a numerical value!");
            }

            return value;
        }
        
        private static string GetValidIsbnNumberFromInput()
        {
            string bookIsbn;
            while (true)
            {
                bookIsbn = Console.ReadLine();

                if (!IsNullOrEmpty(bookIsbn) &&
                    bookIsbn.Length.Equals(LibraryApplicationConstants.LENGTH_OF_ISBN) &&
                    bookIsbn.HasOnlyNumbers())
                {
                    break;
                }
                
                Console.WriteLine("Please enter a correct ISBN!");
            }

            return bookIsbn;
        }

        public bool BookIsbnIsAlreadyInLibrary(LibrarySystem librarySystem, string isbn)
        {
            return librarySystem.RegisteredBooks.Count(b => b.ISBN.Equals(isbn)) == 1;
        }
    }
}