using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIT.Branches
{
    internal class BranchShared
    {
     
        public List<FileSystem> filesSysyem { get; set; }
        public BranchShared() { 
            filesSysyem = new List<FileSystem>();
            
        }

       

    }
}
