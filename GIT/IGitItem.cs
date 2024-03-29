namespace GIT
{
    internal interface IGitItem
    {

        public bool Merge(IGitItem item,Repository project);
        public void Commit();

    }
}
