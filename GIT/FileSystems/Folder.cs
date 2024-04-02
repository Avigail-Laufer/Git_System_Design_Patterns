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
        if (!FatherBranch.isOpenFilesystem)
        {

            List<FileSystem> file = new List<FileSystem>();
            FatherBranch.branch.filesSysyem.ForEach(f => file.Add(f));
            FatherBranch.branch.filesSysyem = file;
            FatherBranch.isOpenFilesystem = true;

        }
       
            folders.Add(item);
            this.Size += item.Size;
            FatherBranch.Size += item.Size;




    }

    public bool Remove(FileSystem item)
    {
        if (!FatherBranch.isOpenFilesystem)
        {

            List<FileSystem> newFile = new List<FileSystem>();
            FatherBranch.branch.filesSysyem.ForEach(f => newFile.Add(f));
            FatherBranch.branch.filesSysyem = newFile;
            FatherBranch.isOpenFilesystem = true;

        }

        FileSystem file = folders.FirstOrDefault(items => items.Name == item.Name);
        if (file!=null) { 
            folders.Remove(file);
            this.Size-= file.Size;
            FatherBranch.Size -= file.Size;
            return true;
        }
        return false;
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

    public void recorsFile()
    {
        foreach (var item in folders)
        {
            if (item.GetType() == typeof(Files))
                item.Review();
            else
            {
                item.Review();
                (item as Folder).recorsFile();
            }
        }
    }

    public FileSystem GetFile(string name)
    {
        foreach (var item in folders)
        {
            if(item.GetType()==typeof(Files)&&item.Name.Equals(name))
            {
               return item; 
            }
            else if (item.Name.Equals(name)) {
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
