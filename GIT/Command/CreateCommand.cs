namespace GIT.Command
{
    internal class CreateCommand : CommandsOnBranch
    {
        public CreateCommand(IGitItem b) : base(b)
        {
        }

        #region function
        public override void Excute()
        {
           ( branch as Branch).Clone();
        }
        #endregion
    }
}
