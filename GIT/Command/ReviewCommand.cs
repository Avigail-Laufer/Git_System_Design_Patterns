namespace GIT.Command
{
    internal class ReviewCommand : CommandsOnBranch
    {
        #region ctor
        public ReviewCommand(IGitItem b) : base(b)
        {
        }
        #endregion

        #region function
        public override void excute()
        {
            branch.Review();
        }
        #endregion
    }
}
