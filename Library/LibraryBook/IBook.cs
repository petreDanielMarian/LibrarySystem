namespace Library.LibraryBook
{
    public interface IBook
    {
        string Name { get; set; }
        string ISBN { get; set; } //TODO 13 characters (numbers)
    }
}