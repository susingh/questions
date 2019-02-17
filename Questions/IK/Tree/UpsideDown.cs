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
            if (root == null)
                return root;

            if (root.left != null)
                flipUpsideDown(root.left);

            root.left.left = root;
            root.left.right = root.left;

            root.left = null;
            root.right = null;

            return root;
        }
    }
}
