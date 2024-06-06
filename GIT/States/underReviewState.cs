namespace GIT.States
{
    internal class underReviewState : State
    {
        public underReviewState(FileSystem file) : base(file)
        {
        }

        #region fuction
        public override void Commit()
        {
            throw new InvalidStateException("No permission to switch to Staged state");
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
            file.ChangeState(new StagedState(file));
        }

        public override void underReview()
        {
            throw new InvalidStateException("You are in the desired state");
        }

        #endregion
    }
}

