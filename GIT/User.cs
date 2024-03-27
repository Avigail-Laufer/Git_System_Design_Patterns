namespace GIT
{
    internal class User
    {
        #region prototype
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string  Password { get; set; }
        List<Repository> repositories { get; set; }=new List<Repository>();


        public User(string name,string email,int age,string password)
        {Name = name;
        Email = email;
        Age = age;
        Password=password;
            
        
        
        }   
     
        #endregion
    }
}
