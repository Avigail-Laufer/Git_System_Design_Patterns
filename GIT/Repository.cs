using System.Drawing;

namespace GIT
{
    internal class Repository
    {
        #region property
        
        Dictionary<string, BranchShared> branchShared;

        public  List<User> usersSharedReposetories;

        List<User> userSuscribe;
        public List<Branch> Branches { get; set; }
        public BranchShared GetBranchShared(string name)
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
        
        public Repository(string name, string description)
        {
            Name = name;
            Description = description;
            Branches = new List<Branch>();
            branchShared = new Dictionary<string, BranchShared>();
            userSuscribe = new List<User>();
            usersSharedReposetories = new List<User>();
        }

        public void Suscribe(User user)
        {
            if(usersSharedReposetories.Contains(user))
            {
                userSuscribe.Add(user);
                Console.WriteLine("Registration was successful");
            }
            else
            {
                Console.WriteLine("You do not have permission to register");
            }

        }
        public void UnSuscribe(User user)
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



        #endregion
    }
}
