using System.Drawing;

namespace GIT
{
    internal class Repository
    {
        #region property
        
        Dictionary<string, BranchShared> branchShared;
        public Repository()
        {
            branchShared = new Dictionary<string, BranchShared>();
        }
        public BranchShared GetEllipseDesign(string name)
        {
            string designKey =name;

            if (!branchShared.ContainsKey(designKey))
            {
                BranchShared newBranchShared = new();
                branchShared[designKey] = newBranchShared;
            }
            return branchShared[designKey];
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Branch> Branches { get; set; }

        public Repository(string name, string description)
        {
            Name = name;
            Description = description;
            Branches = new List<Branch>();
        }
        #endregion
    }
}
