

namespace GIT.States
{
    internal class ErrorState : State
    {
        public ErrorState(FileSystem file) : base(file)
        {
        }
        public override void Commit()
        {
            file.ChangeState(new Draftstate(file));
        }

        public override void Draft()
        {
            throw new NotImplementedException();
        }

        public override void Error()
        {
            throw new InvalidCastException("You are in the ErorState state");
        }


        public override void Staged()
        {
            throw new NotImplementedException();
        }

        public override void underReview()
        {
            file.ChangeState(new Draftstate(file));
        }
    }
}
