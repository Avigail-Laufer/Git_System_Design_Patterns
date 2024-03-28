namespace GIT
{
    internal interface IGitItem
    {
        public bool Delete();

        public bool Merge(IGitItem item,Repository project);
        public void Commit();

    }
}
