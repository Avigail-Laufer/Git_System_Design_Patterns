using GIT.FileSystems;
using System.Xml.Linq;

namespace GIT.Branches
{
    internal class Branch : IGitItem
    {
        #region propertys
        public string Name { get; set; }
        public List<string> Commits { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public BranchShared branch;
        public Repository repository;
        public double Size { get; set; }
        public bool IsOpenFilesystem { get; set; }
        public Branch(string name, Repository repository)
        {
            Name = name;
            ManufacturingDate = DateTime.Now;
            this.repository = repository;
            branch = repository.GetBranchShared(Name);
            Commits = new List<string>();
           IsOpenFilesystem = true;
        }
        public Branch() { }


        #endregion

        #region function

        public bool Delete(Repository repository)
        {
            Console.WriteLine("you soure that you want to delete this branch");
            string c = Console.ReadLine();
            if (c.Equals("yes"))
            {
                repository.Branches.Remove(this);
                return true;
            }
            else
            {
                Console.WriteLine("The request was not accepted");
                return false;
            }
        }
        public bool Merge(IGitItem item, Repository project)
        {

            if (item.GetType() == typeof(Branch))
            {

                // עבור כל קובץ שנמצא באיטם
                (item as Branch).branch.FilesSysyem.ForEach(f =>
                {// תבדןק אם קים קבוץ בעל אותו שם בנוכחי
                    var fs = this.branch.FilesSysyem.Find(ff => ff.Name == f.Name);
                    //אם קים , תמחק אותו
                    if (fs != null && fs.curentState.GetType() == typeof(CommitState))
                    {
                        this.branch.FilesSysyem.Remove(fs);
                        this.branch.FilesSysyem.Add(f);
                    }
                    else if (fs != null) { fs.curentState.Error(); }

                });

                project.Branches.Remove(item as Branch);
            }
            else
            {
                this.branch.FilesSysyem.Add((item as FileSystem));

            }
            Console.WriteLine("I passed from Merge");
            return true;
        }
        public void Commit()
        {
            //Console.WriteLine("enter commit name");
            //string CommitName = Console.ReadLine();
            //if (CommitName!=null) { commit.Add(CommitName); }
            foreach (var file in branch.FilesSysyem)
            {
                if (file.GetType() == typeof(Files))
                {
                    file.curentState.Commit();
                }
                else
                {
                    (file as Folder).curentState.Commit();
                    (file as Folder).RecorsFileToCommit();
                }
            }
            Console.WriteLine("I pass to commit state");
        }
        public void Review()
        {
            repository.Notify();
            foreach (var file in branch.FilesSysyem)
            {
                if (file.GetType() == typeof(Files))
                {
                    file.Review();
                }
                else
                {
                    (file as Folder).RecorsFile();
                }
            }

        }
        public void Add(FileSystem item)
        {

            if (!this.IsOpenFilesystem)
            {

                List<FileSystem> file = new List<FileSystem>();
                this.branch.FilesSysyem.ForEach(f => file.Add(f));
                this.branch.FilesSysyem = file;
                this.IsOpenFilesystem = true;
            }


            this.Size += item.Size;
            item.FatherBranch = this;
            this.branch.FilesSysyem.Add(item);
        }
        public FileSystem GetFileSystem(string name)
        {
            foreach (var item in branch.FilesSysyem)
            {
                if (item.GetType() == typeof(Files) && item.Name.Equals(name))
                {
                    return item;
                }
                return (item as Folder).GetFile(name);

            }
            return null;
        }


        #endregion

    }
}
