namespace Library
{
    public class Book : IBook
    {
        public Book(string name, string isbn, int numberOfCopies, double priceOfReturnDelay)
        {
            Name = name;
            ISBN = isbn;
            NumberOfCopies = numberOfCopies;
            PriceOfReturnDelay = priceOfReturnDelay;
        }

        public string Name { get; set; }
        public string ISBN { get; set; }
        public int NumberOfCopies { get; set; }
        public double PriceOfReturnDelay { get; set; }
    }
}