using System.Collections.Generic;

namespace Library.Menu
{
    public static class MenuOptionsDefinitions
    {
        public static readonly IMenuOption BorrowBook = new BorrowBookMenuOption();
        public static readonly IMenuOption NumberOfCopies = new GetNumberOfCopiesMenuOption();
        public static readonly IMenuOption NumberOfAvailableBooks = new GetAvailableBooksMenuOption();
        public static readonly IMenuOption ReturnBook = new ReturnBookMenuOption();
        public static readonly IMenuOption AddBook = new AddBookMenuOption();
        public static readonly IMenuOption SwitchUsers = new SwitchUserMenuOption();
        public static readonly IMenuOption Exit = new ExitMenuOption();

        public static IEnumerable<IMenuOption> MenuOptions = new List<IMenuOption>
        {
            AddBook,
            BorrowBook,
            ReturnBook,
            NumberOfAvailableBooks,
            NumberOfCopies,
            SwitchUsers,
            Exit
        };
    }
}