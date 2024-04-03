namespace GIT.States
{
    internal class CommitState : State
    {
        public CommitState(FileSystem file) : base(file)
        {
        }

        public override void Commit()
        {
            throw new InvalidStateException("You are in the desired state ");
        }

        public override void Darft()
        {
            file.ChangeState(new Draftstate(file));
        }

        public override void ErorState()
        {
            file.ChangeState(new ErorStates(file));
        }

        public override void Staged()
        {
            throw new InvalidStateException("No permission to switch to Staged state ");
        }

        public override void underReview()
        {
           file.ChangeState(new underReviewState(file));
        }
    }
}
