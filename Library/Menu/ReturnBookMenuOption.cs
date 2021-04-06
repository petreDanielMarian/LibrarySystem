namespace Library.Menu
{
    public class ReturnBookMenuOption : AbstractMenuOption
    {
        public override Permission Permission => Permission.User;
        
        public override string Name => "ReturnBookMenuOption";
        
        public override string Description => "Return a borrowed book back to the library system";
        
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}