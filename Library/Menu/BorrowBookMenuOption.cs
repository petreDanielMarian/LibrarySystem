namespace Library.Menu
{
    public class BorrowBookMenuOption : AbstractMenuOption
    {
        public override Permission Permission => Permission.User;
        
        public override string Name => "BorrowBookMenuOption";
        
        public override string Description => "Borrow a book from the library system";
        
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}