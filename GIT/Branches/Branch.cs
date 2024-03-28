namespace GIT.Branches
{
    internal class Branch : ICloneable, IGitItem
    {
        #region propertys
        public string Name { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public double Size { get; set; }
        public List<FileSystem> GeneralFile { get; set; }
        public Branch()
        {
            GeneralFile = new List<FileSystem>();
        }


        #endregion

        #region function
        public object Clone()
        {
            Branch newBranch = new Branch();
            newBranch.Name = this.Name;
            newBranch.ManufacturingDate=DateTime.Now;
            newBranch.Size = this.Size;
            //האם לעשות את הקבצים prototype?
            return newBranch;

        }
        public bool Delete()
        {
            Console.WriteLine("you soure that you want to delete this branch");
            string c = Console.ReadLine();
            if (c.Equals("yes"))
            {
                this.Delete();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool Merge(IGitItem item, Repository project)
        {
            if(item.GetType() == typeof(Branch)) 
            {
                var newBranch = (Branch)item;
                foreach (var i in newBranch.GeneralFile)
                {
                    this.GeneralFile.Add(i);
                }
             //project.Branches.Remove(item);
            }
            else
            {
                var newFile=(FileSystem)item;
                this.GeneralFile.Add(newFile);
                //צריך למחוק פה את הקובץ מתוך הבראנץ
                //item.Remove();
            }
            Console.WriteLine("I passed from Merge");
            return true;
        }
        public void Commit()
        {
         Console.WriteLine("I pass to commite state");
        }
        #endregion
    }


}
