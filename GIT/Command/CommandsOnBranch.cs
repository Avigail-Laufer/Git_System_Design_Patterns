namespace GIT.Command
{
    abstract class CommandsOnBranch
    {
        protected IGitItem branch { get; private set; }
        public CommandsOnBranch(IGitItem b) { branch = b; }
        
        public abstract void Excute();
    }
}
