using System;
using System.Linq;
using Library.ExtensionMethods;
using Library.LibraryBook;

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
            
            Console.WriteLine("Book name: ");
            string bookName = Console.ReadLine();
            
            Console.WriteLine("Book's ISBN (13 digits): ");
            string bookIsbn = ValidateIsbnNumber();
            
            Console.WriteLine("Number of copies: ");
            int numberOfCopies = ExtractNumericalValueFromInput();

            Console.WriteLine("Price for a delayed return (lei): ");
            int delayedReturnPrice = ExtractNumericalValueFromInput();

            string message;
            if (!BookIsbnIsUnique(librarySystem, bookIsbn))
            {
                message = $"Book with the same ISBN \"{bookIsbn}\" already exists!\nThe book was not registered, please try again!";
                ConsoleHelper.AwaitForAnyKeyPress(message);
                return;
            }
            
            librarySystem.AllRegisteredBooks.Add(new Book(bookName, bookIsbn, numberOfCopies, delayedReturnPrice));
            
            message = $"Book added!";
            ConsoleHelper.AwaitForAnyKeyPress(message);
        }

        private static int ExtractNumericalValueFromInput()
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
        
        private static string ValidateIsbnNumber()
        {
            string bookIsbn;
            while (true)
            {
                bookIsbn = Console.ReadLine();

                if (!string.IsNullOrEmpty(bookIsbn) &&
                    bookIsbn.Length.Equals(LibraryApplicationConstants.LENGTH_OF_ISBN) &&
                    bookIsbn.HasOnlyNumbers())
                {
                    break;
                }
                
                Console.WriteLine("Please enter a correct ISBN!");
            }

            return bookIsbn;
        }

        private static bool BookIsbnIsUnique(LibrarySystem librarySystem, string isbn)
        {
            return librarySystem.AllRegisteredBooks.Count(b => b.ISBN.Equals(isbn)) <= 1;
        }
    }
}