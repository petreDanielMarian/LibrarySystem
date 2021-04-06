using System.Collections.Generic;

namespace Library.Menu
{
    public class MenuOptionsDefinitions
    {
        public static IMenuOption BorrowBook = new BorrowBookMenuOption();
        public static IMenuOption NumberOfTitles = new GetNumberOfTitlesMenuOption();
        public static IMenuOption NumberOfAvailableBooks = new GetNumberOfAvailableBooksMenuOption();
        public static IMenuOption ReturnBook = new ReturnBookMenuOption();
        public static IMenuOption AddBook = new AddBookMenuOption();
        public static IMenuOption Exit = new ExitMenuOption();

        public static IEnumerable<IMenuOption> MenuOptions = new List<IMenuOption>
        {
            BorrowBook,
            NumberOfTitles,
            NumberOfAvailableBooks,
            ReturnBook,
            AddBook,
            Exit
        };
    }
}