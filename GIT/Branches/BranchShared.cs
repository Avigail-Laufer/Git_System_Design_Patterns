using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIT.Branches
{
    internal class BranchShared
    {
     
        public List<FileSystem> FilesSysyem { get; set; }
        public BranchShared() { 
            FilesSysyem = new List<FileSystem>();
            
        }

       

    }
}
