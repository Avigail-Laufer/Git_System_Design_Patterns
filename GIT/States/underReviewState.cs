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

        public override void Darft()
        {
            file.ChangeState(new Draftstate(file));
        }

        public override void ErorState()
        {
            file.ChangeState(new ErorStates(file));
        }

        public override void GetMessage()
        {
            throw new NotImplementedException();
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

