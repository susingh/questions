using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Recursion
{
    class CountBST
    {
        public static int Count_BST(int n)
        {
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = i + 1;
            }

            TreeNode root = null;
            return Count_BST(arr, 0, n - 1, root);
        }

        private static int Count_BST(int[] arr, int start, int end, TreeNode node)
        {
            if (start == end)
            {
                node = new TreeNode(arr[start]);
                return 1;
            }

            if (start > end)
            {
                node = null;
                return 0;
            }

            int total = 0;

            for (int i = start; i <= end; i++)
            {
                node = new TreeNode(i);
                int left = Count_BST(arr, start, i - 1, node.left);
                int right = Count_BST(arr, i + 1, end, node.right);

                total += left *   right;
            }

            return total;
        }
    }
}
