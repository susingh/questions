using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Tree
{
    class FindMax
    {
        public static int FindMaxValue(TreeNode root)
        {
            if (root == null)
                return 0;

            int maxChildren = Math.Max(FindMaxValue(root.left), FindMaxValue(root.left));
            return Math.Max(root.val, maxChildren);
        }
    }
}
