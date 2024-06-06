// See https://aka.ms/new-console-template for more information
#region user
User studentUser = new User("Avigail", "al3293374@gmail.com", 20, "326254612");
User teacherUser = new User("Ayala", "Ayala767@gmail.com", 20, "567853469");
#endregion

#region reposetory
Repository angular = new Repository("angular", "final project angular");
Repository sql = new Repository("sql", "HM sql");
Repository pytonProject = new Repository("pytonProject", "hard pyton Project");
Repository java8 = new Repository("java8", "java8 project");
#endregion

#region branch
Branch branch1 = new Branch("start project", angular);
Branch branch2 = new Branch("start pyton project", pytonProject);
Branch branch3 = new Branch("hm in sql", sql);
Branch branch4 = new Branch("in project", java8);
#endregion

#region addBranchToRep
angular.AddBranches(branch1);
sql.AddBranches(branch3);
pytonProject.AddBranches(branch2);
java8.AddBranches(branch4);

studentUser.AddRep(angular);
studentUser.AddRep(pytonProject);
teacherUser.AddRep(java8);
teacherUser.AddRep(sql);
#endregion

#region folder
Folder MainFolder = new Folder("src", 2.6);
Folder componts = new Folder("componts", 2.3);
Folder services = new Folder("services", 2.2);
Folder utils = new Folder("utils", 2);
Files app = new Files("app.js", 6.5);
Files index = new Files("index.js", 5.5);
Files BookList = new Files("BookList.js", 4.5);
Files BookForm = new Files("BookForm.js", 2.5);
Files BookDetails = new Files("BookDetails.js", 3.3);
Files bookService = new Files("bookService.js", 3.7);
Files formatDate = new Files("formatDate.js", 3.6);

branch1.Add(MainFolder);
branch2.Add(componts);
branch3.Add(services);
branch4.Add(utils);


MainFolder.Add(componts);
MainFolder.Add(services);
MainFolder.Add(utils);
MainFolder.Add(app);
MainFolder.Add(index);
componts.Add(BookList);
componts.Add(BookForm);
componts.Add(BookDetails);
services.Add(bookService);
utils.Add(formatDate);

//app.AddContext("ggggggggggggggggggggggg");
//app.Commit();
//app.ChangeState(new Draftstate(app));
//app.AddContext("jkkkkkkkkkkkkkkkkkkkkkkkkk");
//app.Commit();
#endregion

#region clone
Branch branch5 = pytonProject.Clone(branch4);
Branch branch6 = java8.Clone(branch3);
pytonProject.AddOther(teacherUser);
//מראה את יצירת הרשימה 
branch6.Add(new Folder("hhhh",0));
//רפוזתורי שמעונין לקבל התראה כשבראנצים אחרים מבקשים revew
pytonProject.Subscribe(teacherUser);
#endregion

#region GitCommandManager
//אין אפשרות לעבור בין מצבים אלו
//index.curentState.underReview();
GitCommandManager commandManager = GitCommandManager.GetInstance();
CommitCommand commitCommand1 = new CommitCommand(index);
CommitCommand commitCommand2 = new CommitCommand(branch5);
MergeCommand mergeCommand3 = new MergeCommand(branch5,branch1,angular);
ReviewCommand reviewCommand=new ReviewCommand(branch5);
DeleteCommand deleteCommand1 = new DeleteCommand(branch1,angular);
commandManager.RunTheTask(commitCommand1);
commandManager.RunTheTask(commitCommand2);
commandManager.RunTheTask(mergeCommand3);
commandManager.RunTheTask(reviewCommand);
commandManager.RunTheTask(deleteCommand1);
#endregion




