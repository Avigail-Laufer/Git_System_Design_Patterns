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
            throw new NotImplementedException();
        }
        public Boolean Delete()
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
        public Boolean Merge(IGitItem item)
        {
            Console.WriteLine("I passed from Merge");
            return true;
        }
        public void Review()
        {
         
        }
        public void Commit()
        {
         Console.WriteLine("I pass to commite state");
        }
        #endregion
    }


}
