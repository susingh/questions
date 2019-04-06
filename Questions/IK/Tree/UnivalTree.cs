using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Tree
{
    class UnivalTree
    {
        public static int FindUnivalTrees(TreeNode root)
        {
            if (root == null)
            {
                return -1;
            }

            if (root.left == null && root.right == null)
            {
                // single valued tree
                return 1;
            }

            int left = FindUnivalTrees(root.left);
            int right = FindUnivalTrees(root.right);

            if (root.val == root.left.val && root.val == root.right.val)
            {
                return left + right + 1;
            }
            else
            {
                return left + right;
            }
        }
    }
}