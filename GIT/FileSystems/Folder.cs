namespace GIT.FileSystems;


internal class Folder : FileSystem
{
    #region proprtys
    public List<FileSystem> Folders { get; private set; }
    public Folder(string name, double size) : base(name, size)
    {
        Folders = new List<FileSystem>();
    }
    #endregion

    #region function
    public void Clear()
    {
        Folders.Clear();
    }
    public bool Contains(FileSystem item)
    {
        if (Folders.Contains(item)) { return true; }
        return false;
    }
    public void Add(FileSystem item)
    {
        item.FatherBranch = this.FatherBranch;
        if (!FatherBranch.IsOpenFilesystem)
        {
            List<FileSystem> file = new List<FileSystem>();
            FatherBranch.branch.FilesSysyem.ForEach(f => file.Add(f));
            FatherBranch.branch.FilesSysyem = file;
            FatherBranch.IsOpenFilesystem = true;
        }

        Folders.Add(item);
        this.Size += item.Size;
        FatherBranch.Size += item.Size;




    }
    public bool Remove(FileSystem item)
    {
        if (!FatherBranch.IsOpenFilesystem)
        {
            List<FileSystem> newFile = new List<FileSystem>();
            FatherBranch.branch.FilesSysyem.ForEach(f => newFile.Add(f));
            FatherBranch.branch.FilesSysyem = newFile;
            FatherBranch.IsOpenFilesystem = true;
        }

        FileSystem file = Folders.FirstOrDefault(items => items.Name == item.Name);
        if (file != null)
        {
            Folders.Remove(file);
            this.Size -= file.Size;
            FatherBranch.Size -= file.Size;
            return true;
        }
        return false;
    }
    public override string ShowDetails(int depth)
    {
        string indent = base.ShowDetails(depth);
        string s = $"{indent}{nameof(Folder)}- name: {Name}, size: {Size}KB";
        foreach (var item in Folders)
        {
            s += "\n";
            s += item.ShowDetails(depth + 1);
        }
        return s;
    }
    public void RecorsFile()
    {
        foreach (var item in Folders)
        {
            if (item.GetType() == typeof(Files))
                item.Review();
            else
            {
                item.Review();
                (item as Folder).RecorsFile();
            }
        }
    }
    public void RecorsFileToCommit()
    {
        
        foreach (var item in Folders)
        {
            if (item.GetType() == typeof(Files))
                item.curentState.Commit();
            else
            {
                item.curentState.Commit();
                (item as Folder).RecorsFile();
            }
        }
    }
    public FileSystem GetFile(string name)
    {
        foreach (var item in Folders)
        {
            if (item.GetType() == typeof(Files) && item.Name.Equals(name))
            {
                return item;
            }
            else if (item.Name.Equals(name))
            {
                return item;
            }
            else
            {
                return (item as Folder).GetFile(name);
            }

        }
        return null;
    }

    #endregion

}
