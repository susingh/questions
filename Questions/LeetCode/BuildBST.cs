using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.LeetCode
{
    /*
 * Definition for a binary tree node.
 */
    public class BuildBST
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums.Length == 0)
            {
                return null;
            }

            return SortedArrayToBST(nums, 0, nums.Length - 1);
        }

        private TreeNode SortedArrayToBST(int[] nums, int startIndex, int endIndex)
        {
            int count = endIndex - startIndex + 1;
            int middle = count % 2 == 0 ? count / 2 : count / 2 + 1;
            middle = middle - 1;

            int effectiveIndex = startIndex + middle;
            TreeNode node = new TreeNode(nums[effectiveIndex]);

            if (effectiveIndex - 1 >= startIndex)
            {
                node.left = SortedArrayToBST(nums, startIndex, effectiveIndex - 1);
            }

            if (effectiveIndex + 1 <= endIndex)
            {
                node.right = SortedArrayToBST(nums, effectiveIndex + 1, endIndex);
            }

            return node;
        }

        public void Run()
        {
            //var result = SortedArrayToBST(new int[] { -10, -3, 0, 5, 9 });
            var result = SortedArrayToBST(new int[] { 0, 1, 2, 3, 4, 5});
        }
    }
}
