using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServerTrees
{
    public class TreeNode
    {
        #region variables   
        public TreeNode iz;
        public int dat;
        public TreeNode de;
        #endregion
        public TreeNode(int dat)
        {
            this.dat = dat;
            de = iz = null;
        }
    }
}