using System.Drawing;

namespace GIT
{
    internal class Repository : Iclone
    {
        #region property

        Dictionary<string, BranchShared> branchShared;

        public List<User> usersSharedReposetories;

        List<User> userSuscribe;
        public List<Branch> Branches { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Repository(string name, string description)
        {
            Name = name;
            Description = description;
            Branches = new List<Branch>();
            branchShared = new Dictionary<string, BranchShared>();
            userSuscribe = new List<User>();
            usersSharedReposetories = new List<User>();
        }

        #region func
        public BranchShared GetBranchShared(string name)
        {
            string designKey = name;

            if (!branchShared.ContainsKey(designKey))
            {
                BranchShared newBranchShared = new();
                branchShared[designKey] = newBranchShared;
            }
            return branchShared[designKey];
        }
        public void Subscribe(User user)
        {
            if (usersSharedReposetories.Contains(user))
            {
                userSuscribe.Add(user);
                Console.WriteLine("Registration was successful");
            }
            else
            {
                Console.WriteLine("You do not have permission to register");
            }

        }
        public void UnSubscribe(User user)
        {
            if (usersSharedReposetories.Contains(user))
            {
                userSuscribe.Remove(user);
                Console.WriteLine("The cancellation was successful");
            }
            else
            {
                Console.WriteLine("You are not on the notification list");
            }

        }
        public void Notify()
        {
            userSuscribe.ForEach(user => { user.Update(); });
        }
        public void AddBranches(Branch branch)
        {
            Branches.Add(branch);
        }
        public Branch Clone(Branch branch)
        {

            Branch newBranch = new Branch();
            newBranch.Name = branch.Name;
            newBranch.ManufacturingDate = DateTime.Now;
            newBranch.repository = this;
            newBranch.branch = branch.repository.GetBranchShared(branch.Name);
            newBranch.IsOpenFilesystem = false;
            this.AddBranches(newBranch);
            return newBranch;
        }
        public bool AddOther(User user)
        {
            if(user!=null)
            {
                usersSharedReposetories.Add(user);
                user.repositories.Add(this);    
                return true;
            }
            return false;
        }
        #endregion


        #endregion
    }
}
