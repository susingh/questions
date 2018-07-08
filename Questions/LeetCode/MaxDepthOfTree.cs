using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.LeetCode
{
    public class MaxDepthOfTree
    {
        public int MaxDepth(TreeNode root)
        {
            return FindDepth(root, 0);
        }

        int FindDepth(TreeNode root, int level)
        {
            if (root == null)
            {
                return level;
            }

            level = level + 1;

            int leftDepth = FindDepth(root.left, level);
            int rightDepth = FindDepth(root.right, level);

            return Math.Max(leftDepth, rightDepth);
        }

        public void Run()
        {
            TreeNode root = new TreeNode(10)
            {
                left = new TreeNode(5)
                {
                    left = new TreeNode(6)
                    {
                        right = new TreeNode(2)
                        {
                            left = new TreeNode(3)
                        }
                    }
                },
                right = new TreeNode(7)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(1)
                    {
                        right = new TreeNode(0)
                    }
                }
            };

            Console.WriteLine(MaxDepth(root));
        }
    }
}
