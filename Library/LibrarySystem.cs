using System.Collections.Generic;
using Library.LibraryBook;

namespace Library
{
    public class LibrarySystem
    {
        private LibrarySystem()
        {
            AllBorrowedBookForms = new List<BorrowedBookForm>();
            AllRegisteredBooks = new List<Book>();
        }

        public static LibrarySystem Instance { get; } = new LibrarySystem();
        public IList<Book> AllRegisteredBooks { get; }
        public IList<BorrowedBookForm> AllBorrowedBookForms { get; }
    }
}