namespace GIT.Memento
{
    internal class FileStateMemento:IMemento
    {
        Stack<string> historyFile=new Stack<string>();
        public FileStateMemento() { }

        public void Save(FileSystem file)
        { 
            if(file.GetType()==typeof (Files))
            historyFile.Push((file as Files).Context);
            else
            historyFile.Push((file as Folder).Name);
        }
        public string Restore()
        {
            return historyFile.Pop();
        }

    }
}
