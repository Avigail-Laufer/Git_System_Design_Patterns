using GIT.Memento;
using System.Xml.Linq;

namespace GIT.Command
{
    internal class GitCommandManager
    {
        Queue<CommandsOnBranch> TaskToExecute = new Queue<CommandsOnBranch>();
        private GitCommandManager() { }

        private static GitCommandManager _instance;

        private static readonly object _lock = new object();
        public void RunTheTask(CommandsOnBranch command)
        {
            TaskToExecute.Enqueue(command);
            var commandToExecute = TaskToExecute.Dequeue();
            commandToExecute.Excute();
           
        }
        public static GitCommandManager GetInstance()
        {

            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new GitCommandManager();
                    }
                }
            }
            return _instance;
        }

    }
}
