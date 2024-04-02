using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIT.Memento
{
    internal interface IMemento
    {
        public void save(FileSystem file);

        public string restore();
       
    }
}
