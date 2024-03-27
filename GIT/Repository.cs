namespace GIT
{
    internal class Repository
    {
        #region property
        public string Name { get; set; }
        public string Description { get; set; }
        List<Branch> Branches { get; set; }

        public Repository(string name, string description)
        {
            Name = name;
            Description = description;
            Branches = new List<Branch>();
        }
        #endregion
    }
}
