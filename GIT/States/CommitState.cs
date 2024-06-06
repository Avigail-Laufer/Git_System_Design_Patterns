namespace GIT.States
{
    internal class CommitState : State
    {
        #region Func
        public CommitState(FileSystem file) : base(file)
        {
        }

        public override void Commit()
        {
            throw new InvalidStateException("You are in the desired state ");
        }

        public override void Draft()
        {
            file.ChangeState(new Draftstate(file));
        }

        public override void Error()
        {
            file.ChangeState(new ErrorState(file));
        }

        public override void Staged()
        {
            throw new InvalidStateException("No permission to switch to Staged state ");
        }

        public override void underReview()
        {
           file.ChangeState(new underReviewState(file));
        }
        #endregion
    }
}
