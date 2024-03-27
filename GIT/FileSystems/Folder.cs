namespace GIT.FileSystems;


internal class Folder : FileSystem
{
    #region proprtys
    public List<FileSystem> folders { get;private set; }
    public Folder(string name,double size):base(name,size) {
        folders = new List<FileSystem>();
    }
    #endregion

    #region function
    public void Clear()
    {
        folders.Clear();
    }

    public bool Contains(FileSystem item)
    {
        if (folders.Contains(item)){ return true; }
        return false;
    }

    public void Add(FileSystem item)
    {
       folders.Add(item);
        this.Size+= item.Size;
    }

    public bool Remove(FileSystem item)
    {
        FileSystem file=folders.Find(item=>item.Name==Name);
        if (file!=null) { 
            folders.Remove(file);
            this.Size-= file.Size;
            return true;
        }
        return false;
    }

    public void RemoveAt(int index)
    {
       folders.RemoveAt(index);
        this.Size-= index;
    }

    public override string ShowDetails(int depth)
    {
        string indent = base.ShowDetails(depth);
        string s=$"{indent}{nameof(Folder)}- name: {Name}, size: {Size}KB";
       

        foreach (var item in folders)
        {
            s += "\n";
            s += item.ShowDetails(depth + 1);
        }
        return s;
    }
    #endregion

}
