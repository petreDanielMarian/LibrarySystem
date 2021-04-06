namespace Library.Menu
{
    public abstract class AbstractMenuOption : IMenuOption
    {
        public virtual Permission Permission { get; }
        public virtual string Name { get; }
        public virtual string Description { get; }

        public virtual void Execute(LibrarySystem librarySystem)
        {
            //Not implemented
        }

        #region Equality

        public override bool Equals(object obj) => Equals(obj as IMenuOption);

        private bool Equals(IMenuOption menuOption)
        {
            return menuOption != null && Name.Equals(menuOption.Name);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int) Permission;
                hashCode = (hashCode * 397) ^ (Name != null ? Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Description != null ? Description.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion
        
        public override string ToString()
        {
            return Description;
        }
    }
}