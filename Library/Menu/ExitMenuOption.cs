using System;

namespace Library.Menu
{
    public class ExitMenuOption : AbstractMenuOption
    {
        public override Permission Permission => Permission.All;

        public override string Name => "ExitMenuOption";
        
        public override string Description => "Exit the application";
        
        public override void Execute(LibrarySystem librarySystem)
        {
            Console.Clear();
            Console.WriteLine("Thank you for using our system!");
            Environment.Exit(1);
        }
    }
}