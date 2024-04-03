namespace GIT.Memento
{
    internal class FileStateMemento:IMemento
    {
        Stack<string> historyFile=new Stack<string>();
        public FileStateMemento() { }

        public void save(FileSystem file)
        { 
            if(file.GetType()==typeof (Files))
            historyFile.Push((file as Files).context);
            else
            historyFile.Push((file as Folder).Name);
        }
        public string restore()
        {
            return historyFile.Pop();
        }

    }
}
