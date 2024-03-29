namespace GIT.Command
{
    internal class CommitCommand : CommandsOnBranch
    {
        #region propertys
        public CommitCommand(IGitItem b) : base(b)
        {
        }
        #endregion


        #region function
        public override void Excute()
        {
            branch.Commit();
        }
        #endregion
    }
}
