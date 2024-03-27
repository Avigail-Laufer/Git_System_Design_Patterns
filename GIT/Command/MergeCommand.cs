namespace GIT.Command
{
    internal class MergeCommand : CommandsOnBranch
    {
        #region ctor
        public IGitItem item { get; set; }
        public MergeCommand(IGitItem b, IGitItem item) : base(b)
        {
            this.item = item;
        }
        #endregion

        #region function
        public override void excute()
        {
            branch.Merge(item);
        }
        #endregion
    }
}
