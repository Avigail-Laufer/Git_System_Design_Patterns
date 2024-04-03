namespace GIT
{
    internal class User 
    {
        #region property

        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public List<Repository> repositories { get; set; } = new List<Repository>();


        public User(string name, string email, int age, string password)
        {
            Name = name;
            Email = email;
            Age = age;
            Password = password;
        }

        public void Sharing(string name, User user)
        {
            Repository newRepository = repositories.FirstOrDefault(r => r.Name == name);
            if (newRepository != null)
            {
                newRepository.usersSharedReposetories.Add(user);
                user.repositories.Add(newRepository);
                Console.WriteLine($"the Repository: {newRepository} add to {user} repository ");
            }


        }
        public void AddRep(Repository repository)
        {
            this.repositories.Add(repository);
            repository.usersSharedReposetories.Add(this);


        }
        public void Update()
        {
            Console.WriteLine($"user: {this.Name} Received a revew request ");
        }
       

        #endregion
    }
}
