namespace Library.Menu
{
    //TODO
    public abstract class AbstractMenuOption : IMenuOption
    {
        public virtual Permission Permission { get; }
        public virtual string Name { get; }
        public virtual string Description { get; }

        public void Execute()
        {
            //Not implemented
        }

        #region Equality

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            IMenuOption menuOption = (IMenuOption) obj;
            return Name.Equals(menuOption.Name);
        }

        #endregion
        public override string ToString()
        {
            return Description;
        }
    }
    
}