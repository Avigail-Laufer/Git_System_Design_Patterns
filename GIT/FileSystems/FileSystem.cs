using GIT.Memento;

namespace GIT.FileSystems;

internal abstract class FileSystem : IGitItem
{
    #region proprtys
    public State curentState { get; set; }
    public string Name { get; set; }
    public double Size { get; set; }
    public Branch FatherBranch { get; set; }
    public IMemento fileHistory { get; set; }
    public FileSystem(string name, double size)
    {
        Name = name;
        Size = size;
        curentState = new Draftstate(this);
        fileHistory = new FileStateMemento();

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
      curentState.underReview();
        
    }
    public void Commit()
    {
        if (this.curentState.GetType() == typeof(Draftstate))
        {
            Console.WriteLine("enter commit name");
            string CommitName=Console.ReadLine();
            this.FatherBranch.commit.Add(CommitName);
            fileHistory.save(this);
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
        this.Name = fileHistory.restore().Name;
        this.Size = fileHistory.restore().Size;
        this.curentState = fileHistory.restore().curentState;

    }

    #endregion
}
