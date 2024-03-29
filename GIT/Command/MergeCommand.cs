namespace GIT.Command
{
    internal class MergeCommand : CommandsOnBranch
    {
        #region ctor
        public IGitItem item { get; set; }
        public Repository project { get; set; }
        public MergeCommand(IGitItem b, IGitItem item , Repository project) : base(b)
        {
            this.item = item;
            this.project = project;
        }
        #endregion

        #region function
        public override void Excute()
        {
            branch.Merge(item,project);
        }
        #endregion
    }
}
