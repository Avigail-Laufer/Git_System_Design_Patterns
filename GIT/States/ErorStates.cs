

namespace GIT.States
{
    internal class ErorStates : State
    {
        public ErorStates(FileSystem file) : base(file)
        {
        }
        public override void Commit()
        {
            file.ChangeState(new Draftstate(file));
        }

        public override void Darft()
        {
            throw new NotImplementedException();
        }

        public override void ErorState()
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
