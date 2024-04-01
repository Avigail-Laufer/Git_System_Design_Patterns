namespace GIT.Memento
{
    internal class FileStateMemento:IMemento
    {
        Stack<FileSystem> historyFile;
        public FileStateMemento() { }

        public void save(FileSystem file)
        {
            historyFile.Push(file);
        }
        public FileSystem restore()
        {
            return historyFile.Pop();
        }

    }
}
