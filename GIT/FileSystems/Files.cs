namespace GIT.FileSystems;
internal class Files : FileSystem
{
    #region propertys

    public string Context { get; set; }
    public Files(string name, double size) : base(name, size)
    {
       
    }
    #endregion

    #region function
    public override string ShowDetails(int depth)
    => $"{base.ShowDetails(depth)}{nameof(File)}- name: {Name}, size: {Size}KB";

    public void AddContext(string context) 
    { 
        this.Context += context;
    }
    #endregion

}
