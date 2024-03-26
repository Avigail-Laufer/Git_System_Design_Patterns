using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIT.Branches
{
    internal class Branch:ICloneable
    {
        #region proprty
        public string Name { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public double Size { get; set; }
        //public list<fileSystem> GeneralFile { get; set; }
        public Branch() { }


        #endregion

        #region function
        public object Clone()
        {
            throw new NotImplementedException();
        }
        public  Boolean Delete()
        {
            return true;
        }
        public Boolean Merge()
        {
            return false;
        }
        public void Review()
        {

        }
        public void Commit()
        {

        }
        #endregion
    }


}
