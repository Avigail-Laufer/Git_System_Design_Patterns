namespace GIT.FileSystems;

internal abstract class FileSystem : IGitItem
{
    #region proprtys
    public State curentState { get; set; }
    public string Name { get; set; }
    public double Size { get; set; }
    public FileSystem(string name, double size)
    {
        Name = name;
        Size = size;
        curentState = new Draftstate(this);
    }
    #endregion

    #region function
    public void ChangeState(State newState)
    {
        curentState = newState;
    }
    public virtual string ShowDetails(int depth)
    {
        string indent = "";
        for (int i = 0; i < depth; i++, indent += "\t") ;
        return indent;
    }
    public bool remove(IGitItem item)
    {
        item=null;
        return true;
    }
    public bool Delete()
    {
        Console.WriteLine("you soure that you want to delete this file");
        string c = Console.ReadLine();
        if (c.Equals("yes"))
        {
            remove(this);
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool Merge(IGitItem item,Repository project)
    {

        if (this.GetType()==typeof(File)&&item.GetType()!=typeof(File)|| this.GetType() == typeof(Folder) && item.GetType() != typeof(Branch))
        {
            this.curentState.ErorState();
            return false;
        }
        if(this.curentState.GetType()==typeof(CommitState))
        {
            this.curentState.ErorState();
            return false;
        }
        //צריך להעביר את התוכן ולמחוק
        FileSystem f = (FileSystem)item;
        f.curentState.Staged();
        Console.WriteLine("I passed from Merge");
        return true;
    }
    public void Review()
    {

    }
    public void Commit()
    {
        if (this.curentState.GetType() == typeof(Draftstate))
        {
            Console.WriteLine("I pass to commite state");
            this.curentState.underReview();
        }
        else
        {
            Console.WriteLine("The request failed");
            this.curentState.ErorState();
        }

    }
    public void UndoTheCommit()
    {
        switch (this.curentState)
        {
            case CommitState:
                  ChangeState(new Draftstate(this));
                break;
            case underReviewState:
                ChangeState(new Draftstate(this));
                break;
            case State:
                throw new InvalidStateException("you dont showld to commited");
        }
       

    }
    #endregion
}
