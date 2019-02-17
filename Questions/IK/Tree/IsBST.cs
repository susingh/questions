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

        private static bool isBSTRecursive(TreeNode root)
        {
            return isBSTRecursive(root, int.MinValue, int.MaxValue);
        }

        private static bool isBSTRecursive(TreeNode root, int min, int max)
        {
            if (root == null)
                return true;

            if (root.val >= max || root.val <= min)
                return false;

            return isBSTRecursive(root.left, min, root.val) && isBSTRecursive(root.right, root.val, max);
        }
    }
}
