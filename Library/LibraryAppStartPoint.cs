using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{    
    public class LibraryAppStartPoint
    {
        public static void Main(string[] args)
        {
            IList<Permission> users = Enum.GetValues(typeof(Permission)).Cast<Permission>().ToList();
            users.Remove(Permission.All); //Get rid of the generic permission to get a list of possible users
            
            Permission selectedUserType = ConsoleHelper.MultipleChoicePrompter(users);

            LibraryApplication.Run(selectedUserType);
        }
    }
}