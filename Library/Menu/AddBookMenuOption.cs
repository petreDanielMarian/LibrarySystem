namespace Library.Menu
{
    public class AddBookMenuOption : AbstractMenuOption
    {
        public override Permission Permission => Permission.Admin;
        
        public override string Name => "AddBookMenuOption";
        
        public override string Description => "Add a new book to the library system";
        
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}