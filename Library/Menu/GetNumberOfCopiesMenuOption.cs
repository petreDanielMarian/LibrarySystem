using System.Linq;
using Library.LibraryBook;

namespace Library.Menu
{
    public class GetNumberOfCopiesMenuOption : AbstractMenuOption
    {
        public override Permission Permission => Permission.All;
        
        public override string Name => "GetNumberOfCopiesMenuOption";
        
        public override string Description => "Get the number of copies of a specific book from the library system";
        
        public override void Execute(LibrarySystem librarySystem)
        {
            if (!librarySystem.RegisteredBooks.Any())
            {
                ConsoleHelper.AwaitForAnyKeyPress("No borrowed books!");
                return;
            }
            
            string message = "Choose a book:\n Name - ISBN";
            Book book = ConsoleHelper.MultipleChoicePrompter(librarySystem.RegisteredBooks.OrderBy(b => b.Name).ToList(), message);
            
            string awaitMessage = $"Book titled \"{book.Name}\" has {book.NumberOfCopies} copies in our library, the rest of {book.NumberOfBorrowedCopies} are borrowed";
            ConsoleHelper.AwaitForAnyKeyPress(awaitMessage);
        }
    }
}