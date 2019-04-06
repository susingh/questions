using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Tree
{
    class IdenticalTrees
    {
        public static bool IsIdentitcal(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null)
                return true;
            else if (root1 == null || root2 == null)
                return false;

            return root1.val == root2.val && IsIdentitcal(root1.left, root2.left) && IsIdentitcal(root1.right, root2.right);
        }
    }
}
