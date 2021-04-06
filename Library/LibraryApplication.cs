using System;
using System.Collections.Generic;
using System.Linq;
using Library.Menu;

namespace Library
{
    public static class LibraryApplication
    {
        public static void Run(Permission selectedUserType)
        {
            IMenuOption selectedClass;
            IList<IMenuOption> list = MenuOptionsDefinitions.MenuOptions.Where(mo => (mo.Permission & selectedUserType) == selectedUserType).ToList();
            do
            {
                selectedClass = ConsoleHelper.MultipleChoicePrompter(list);
                selectedClass.Execute();
                
            } while (Console.ReadKey(true).Key == ConsoleKey.Escape);
            
            Console.WriteLine("\nThe app will now exit! Thanks for using it!");
        }
    }
}