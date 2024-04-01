namespace GIT.FileSystems;
internal class Files : FileSystem
{
    #region propertys
    
    public Files(string name, double size) : base(name, size)
    {
       
    }
    #endregion

    #region function
    public override string ShowDetails(int depth)
    => $"{base.ShowDetails(depth)}{nameof(File)}- name: {Name}, size: {Size}KB";

    #endregion

}
