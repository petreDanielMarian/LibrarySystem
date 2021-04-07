using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Library.LibraryBook;

namespace Library
{
    public class LibrarySystem
    {
        private LibrarySystem()
        {
            BorrowedBookForms = new List<BorrowedBookForm>();
            RegisteredBooks = new List<Book>();
        }

        public static LibrarySystem Instance { get; } = new LibrarySystem();
        public IList<Book> RegisteredBooks { get; }
        public IList<BorrowedBookForm> BorrowedBookForms { get; }
    }
}