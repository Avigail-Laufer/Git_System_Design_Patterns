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
        public override void Excute()
        {
            branch.Review();
        }
        #endregion
    }
}
