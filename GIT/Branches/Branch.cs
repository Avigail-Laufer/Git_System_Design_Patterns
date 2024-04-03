using GIT.FileSystems;
using System.Xml.Linq;

namespace GIT.Branches
{
    internal class Branch : IGitItem
    {
        #region propertys
        public string Name { get; set; }
        public List<string> commit { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public BranchShared branch;
        public Repository repository;
        public double Size { get; set; }
        public bool isOpenFilesystem { get; set; }
        public Branch(string name, Repository repository)
        {
            Name = name;
            ManufacturingDate = DateTime.Now;
            this.repository = repository;
            branch = repository.GetBranchShared(Name);
            commit = new List<string>();
            isOpenFilesystem = true;
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
                (item as Branch).branch.filesSysyem.ForEach(f =>
                {// תבדןק אם קים קבוץ בעל אותו שם בנוכחי
                    var fs = this.branch.filesSysyem.Find(ff => ff.Name == f.Name);
                    //אם קים , תמחק אותו
                    if (fs != null && fs.curentState.GetType() == typeof(CommitState))
                    {
                        this.branch.filesSysyem.Remove(fs);
                        this.branch.filesSysyem.Add(f);
                    }
                    else if (fs != null) { fs.curentState.ErorState(); }

                });

                project.Branches.Remove(item as Branch);
            }
            else
            {
                this.branch.filesSysyem.Add((item as FileSystem));

            }
            Console.WriteLine("I passed from Merge");
            return true;
        }
        public void Commit()
        {
            //Console.WriteLine("enter commit name");
            //string CommitName = Console.ReadLine();
            //if (CommitName!=null) { commit.Add(CommitName); }
            foreach (var file in branch.filesSysyem)
            {
                if (file.GetType() == typeof(Files))
                {
                    file.curentState.Commit();
                }
                else
                {
                    (file as Folder).curentState.Commit();
                    (file as Folder).recorsFileToCommit();
                }
            }
            Console.WriteLine("I pass to commit state");
        }
        public void Review()
        {
            repository.Notify();
            foreach (var file in branch.filesSysyem)
            {
                if (file.GetType() == typeof(Files))
                {
                    file.Review();
                }
                else
                {
                    (file as Folder).recorsFile();
                }
            }

        }
        public void Add(FileSystem item)
        {

            if (!this.isOpenFilesystem)
            {

                List<FileSystem> file = new List<FileSystem>();
                this.branch.filesSysyem.ForEach(f => file.Add(f));
                this.branch.filesSysyem = file;
                this.isOpenFilesystem = true;
            }


            this.Size += item.Size;
            item.FatherBranch = this;
            this.branch.filesSysyem.Add(item);
        }
        public FileSystem GetFileSystem(string name)
        {
            foreach (var item in branch.filesSysyem)
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
