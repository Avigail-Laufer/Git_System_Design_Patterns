namespace GIT.States
{
    internal class StagedState : State
    {
        public StagedState(FileSystem file) : base(file)
        {
        }

        public override void Commit()
        {
            throw new InvalidStateException("You are in the desired state ");
        }

        public override void Darft()
        {
            throw new InvalidStateException("No permission to switch to Staged state ");
        }

        public override void ErorState()
        {
           file.ChangeState(new ErorStates(file));
        }


        public override void Staged()
        {
            throw new InvalidStateException("You are in the desired state ");

        }


        public override void underReview()
        {
            throw new InvalidStateException("No permission to switch to Staged state ");
        }
    }
}
