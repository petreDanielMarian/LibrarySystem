using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Menu
{
    public class SwitchUserMenuOption : AbstractMenuOption
    {
        public override Permission Permission => Permission.All;
        
        public override string Name => "SwitchUserMenuOption";
        
        public override string Description => "Switch users";
        
        public override void Execute(LibrarySystem librarySystem)
        {
            IList<Permission> users = Enum.GetValues(typeof(Permission)).Cast<Permission>().ToList();
            users.Remove(Permission.All); //Get rid of the generic permission to get a list of possible users
            
            LibraryAppStartPoint.SelectedUser = ConsoleHelper.MultipleChoicePrompter(users, "Choose a user");
        }
    }
}