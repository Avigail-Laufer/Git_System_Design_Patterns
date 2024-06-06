using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIT.Memento
{
    internal interface IMemento
    {
        public void Save(FileSystem file);

        public string Restore();
       
    }
}
