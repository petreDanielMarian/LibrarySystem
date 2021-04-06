namespace Library.Menu
{
    public class GetNumberOfTitlesMenuOption : AbstractMenuOption
    {
        public override Permission Permission => Permission.All;
        
        public override string Name => "GetNumberOfTitlesMenuOption";
        
        public override string Description => "Find the number of titles of a specific book from the library system";
        
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}