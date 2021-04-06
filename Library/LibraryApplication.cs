using System.Collections.Generic;
using System.Linq;
using Library.Menu;

namespace Library
{    //TODO Look up naming convention
    public static class LibraryAppStartPoint
    {
        public static Permission SelectedUser { get; set; } = Permission.All;
        public static LibrarySystem LibrarySystem;
        
        public static void Main()
        {
            IMenuOption switchUserAction = new SwitchUserMenuOption();
            switchUserAction.Execute(LibrarySystem.Instance);

            //Start app
            Run();
        }
        
        private static void Run()
        {
            do
            {
                IList<IMenuOption> list = MenuOptionsDefinitions.MenuOptions.Where(mo => (mo.Permission & SelectedUser) == SelectedUser).ToList();
                IMenuOption selectedClass = ConsoleHelper.MultipleChoicePrompter(list, string.Empty);
                selectedClass.Execute(LibrarySystem.Instance);
                
            } while (true);
        }
    }
}