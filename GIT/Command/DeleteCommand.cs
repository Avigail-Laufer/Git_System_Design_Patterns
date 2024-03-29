namespace GIT.Command
{
    internal class DeleteCommand : CommandsOnBranch
    {
        #region ctor
        Repository repository;
        public DeleteCommand(IGitItem b,Repository repository) : base(b)
        {
            this.repository = repository;
        }
        #endregion

        #region function
        public override void Excute()
        {
            if (branch.GetType() == typeof(Branch))
                (branch as Branch).Delete(repository);
        }
        #endregion
    }
}
