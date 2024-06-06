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

        public override void Draft()
        {
            throw new InvalidStateException("No permission to switch to Staged state ");
        }

        public override void Error()
        {
           file.ChangeState(new ErrorState(file));
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
