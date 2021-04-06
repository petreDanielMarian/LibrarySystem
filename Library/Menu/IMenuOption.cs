namespace Library.Menu
{
    public interface IMenuOption
    {
        Permission Permission { get; }
        string Name { get; }
        string Description { get; }
        void Execute(LibrarySystem librarySystem);
    }
}