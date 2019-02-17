using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Tree
{
    class KthSmallest
    {
        public static int kth_smallest_element(TreeNode root, int k)
        {
            int value = -1;
            kth_smallest_element(root, k, out value);
            return value;
        }


        static void kth_smallest_element(TreeNode root, int k, out int value)
        {
            if (root == null)
            {
                value = -1;
                return;
            }
            
            kth_smallest_element(root.left, k, out value);

            if (k == 1)
            {
                value = root.val;
                return;
            }

            kth_smallest_element(root.right, k - 1, out value);
        }

    }
}
