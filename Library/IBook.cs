using System;

namespace Library
{
    public interface IBook
    {
        string Name { get; set; }
        string ISBN { get; set; } //TODO 13 characters (numbers)
        int NumberOfCopies { get; set; }
        double PriceOfReturnDelay { get; set; }
    }
}