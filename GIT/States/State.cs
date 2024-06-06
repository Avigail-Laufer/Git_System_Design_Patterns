namespace GIT.States
{
    internal abstract class State
    {
        #region propertys
        protected FileSystem file { get; private set; }
        public State(FileSystem file) {
            this.file = file;
        }
        #endregion

        #region function
        public abstract void Error();
        public abstract void Commit();
        public abstract void underReview();
        public abstract void Staged();
        public abstract void Draft();


        #endregion

    }
}
