namespace Library.Menu
{
    public class GetNumberOfAvailableBooksMenuOption : AbstractMenuOption
    {
        public override Permission Permission => Permission.All;
        
        public override string Name => "GetNumberOfAvailableBooksMenuOption";
        
        public override string Description => "Get all the available (not borrowed) books from the library system";
        
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}