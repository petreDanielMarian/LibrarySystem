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
            Environment.Exit(1);
        }
    }
}