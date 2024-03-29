namespace GIT.Branches
{
    internal class Branch : ICloneable, IGitItem
    {
        #region propertys
        public string Name { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public double Size { get; set; }
        public List<FileSystem> filesSysyem { get; set; }

        public Branch()
        {
            filesSysyem = new List<FileSystem>();
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
                return false;
            }
        }
        public bool Merge(IGitItem item, Repository project)
        {
            if(item.GetType() == typeof(Branch)) 
            {

                // עבור כל קובץ שנמצא באיטם
                (item as Branch).filesSysyem.ForEach(f =>
                {// תבדןק אם קים קבוץ בעל אותו שם בנוכחי
                    var fs = this.filesSysyem.Find(ff => ff.Name == f.Name);
                    //אם קים , תמחק אותו
                    if (fs != null)
                    // תמחק אותו
                    // 
                          this.filesSysyem.Remove(fs);
                   this.filesSysyem.Add(f);   
                    
                   
                });
             
               project.Branches.Remove(item as Branch );
            }
            else
            {
                this.filesSysyem.Add((item as FileSystem));

            }
            Console.WriteLine("I passed from Merge");
            return true;
        }
        public void Commit()
        {

         Console.WriteLine("I pass to commite state");
        }
        public void Review()
        {

        }
        #endregion
    }


}
