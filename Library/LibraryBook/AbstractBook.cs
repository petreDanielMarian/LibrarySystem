namespace Library.LibraryBook
{
    public abstract class AbstractBook : IBook
    {
        public AbstractBook(string name, string isbn)
        {
            Name = name;
            ISBN = isbn;
        }

        public string Name { get; set; }
        public string ISBN { get; set; }

        #region Equality

        public override bool Equals(object obj) => Equals(obj as IBook);

        private bool Equals(IBook book)
        {
            return book != null && ISBN.Equals(book.ISBN);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (ISBN != null ? ISBN.GetHashCode() : 0);
            }
        }

        #endregion

        public override string ToString()
        {
            return $"{Name} - {ISBN}";
        }
    }
}