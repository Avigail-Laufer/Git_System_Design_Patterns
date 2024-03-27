namespace GIT
{
    internal interface IGitItem
    {
        public Boolean Delete();

        public Boolean Merge(IGitItem item);

        public void Review();

        public void Commit();
        
    }
}
