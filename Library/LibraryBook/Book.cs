namespace Library.LibraryBook
{
    public class Book : AbstractBook
    {
        public Book(string name, string isbn, int numberOfCopies, int priceOfReturnDelay) : base(name, isbn)
        {
            NumberOfCopies = numberOfCopies;
            PriceOfReturnDelay = priceOfReturnDelay;
        }
        
        public int NumberOfCopies { get; set; }
        
        public int NumberOfBorrowedCopies { get; set; }
        public int PriceOfReturnDelay { get; set; }
    }
}