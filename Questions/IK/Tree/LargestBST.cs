using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Tree
{
    class LargestBST
    {
        public static int FindLargestBST(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            else if (root.left == null && root.right == null)
            {
                return 1;
            }

            int leftCount = FindLargestBST(root.left);
            int rightCount = FindLargestBST(root.right);

            if (root.left.val <= root.val && root.val < root.right.val)
            {
                return leftCount + rightCount + 1;
            }
            else
            {
                return Math.Max(leftCount, rightCount);
            }
        }
    }
}
