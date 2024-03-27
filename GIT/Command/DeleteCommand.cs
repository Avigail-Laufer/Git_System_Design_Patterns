namespace GIT.Command
{
    internal class DeleteCommand : CommandsOnBranch
    {
        #region ctor
        public DeleteCommand(IGitItem b) : base(b)
        {
        }
        #endregion

        #region function
        public override void excute()
        {
            branch.Delete();
        }
        #endregion
    }
}
