// See https://aka.ms/new-console-template for more information
User studentUser = new User("Avigail", "al3293374@gmail.com", 20, "326254612");
User teacherUser = new User("Ayala", "Ayala767@gmail.com", 20, "567853469");

Repository angular = new Repository("angular","final project angular");
Repository sql = new Repository("sql","HM sql");
Repository pytonProject = new Repository("pytonProject","hard pyton Project");
Repository java8 = new Repository("java8","java8 project");

Branch branch1 = new Branch("start project",angular);
Branch branch2 = new Branch("start pyton project",pytonProject);
Branch branch3 = new Branch("hm in sql",sql);
Branch branch4 = new Branch("in project",java8);

angular.AddBranches(branch1);
sql.AddBranches(branch3);
pytonProject.AddBranches(branch2);
java8.AddBranches(branch4);

studentUser.AddRep(angular);
studentUser.AddRep(pytonProject);
teacherUser.AddRep(java8);
teacherUser.AddRep(sql);


GitCommandManager commandManager = new GitCommandManager();
CreateCommand createBranch = new CreateCommand(branch1);

commandManager.RunTheTask(createBranch);


