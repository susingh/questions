using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Tree
{
    class IsBST
    {
        public static bool isBST(TreeNode node)
        {
            List<int> array = new List<int>();
            inorderTraversal(node, array);
            return isSorted(array);
        }

        private static bool isSorted(List<int> array)
        {
            int max = int.MinValue;
            foreach (var item in array)
            {
                if (max >= item)
                    return false;

                max = item;
            }

            return true;
        }

        private static void inorderTraversal(TreeNode node, List<int> array)
        {
            if (node == null)
            {
                return;
            }

            inorderTraversal(node.left, array);
            array.Add(node.val);
            inorderTraversal(node.right, array);
        }
    }
}
