    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Tree
{
    class UpsideDown
    {
        public static TreeNode flipUpsideDown(TreeNode root)
        {
            if (root.left == null && root.right == null)
                return root;

            var temp = flipUpsideDown(root.left);

            temp.left = root.right;
            temp.right = root;

            root.left = null;
            root.right = null;

            return temp;
        }
    }
}
