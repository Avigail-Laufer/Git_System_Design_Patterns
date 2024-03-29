using GIT.Memento;
using System.Xml.Linq;

namespace GIT.Command
{
    internal class GitCommandManager
    {
        Queue<CommandsOnBranch> TaskToExecute; 
        public void RunTheTask(CommandsOnBranch command)
        {
            TaskToExecute.Enqueue(command);
            var commandToExecute = TaskToExecute.Dequeue();
            commandToExecute.Excute();
        }
        
    }
}
