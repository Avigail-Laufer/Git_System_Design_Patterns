namespace GIT.States
{
    internal class Draftstate : State
    {
        public Draftstate(FileSystem file) : base(file)
        {

        }
        #region function
        public override void Commit()
        {
            file.ChangeState(new CommitState(file)) ;
            Console.WriteLine($"the file - {file.Name} pass to commit state");
        }

        public override void Draft()
        {
            throw new InvalidStateException("You are in the desired state ");
        }

        public override void Error()
        {
            file.ChangeState(new ErrorState(file));
        }

        public override void Staged()
        {
            throw new InvalidStateException("No permission to switch to Staged state");
        }

        public override void underReview()
        {
            throw new InvalidStateException("No permission to switch to underReview state");
        }
        #endregion
    }
}
