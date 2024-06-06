namespace GIT.Command
{
    internal class MergeCommand : CommandsOnBranch
    {
        #region ctor
        public IGitItem Item { get; set; }
        public Repository Project { get; set; }
        public MergeCommand(IGitItem b, IGitItem item , Repository project) : base(b)
        {
            this.Item = item;
            this.Project = project;
        }
        #endregion

        #region function
        public override void Excute()
        {
            branch.Merge(Item,Project);
        }
        #endregion
    }
}
