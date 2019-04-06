using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Tree
{
    class NodesAtLevel
    {
        public static void PrintNodesAtLevel(TreeNode root, int k)
        {
            if (root == null)
                return;

        }

        private static void PrintNodesAtLevelBFS(TreeNode root, int k)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            TreeNode marker = new TreeNode(int.MaxValue);
            q.Enqueue(marker);

            int level = 0;

            while(q.Count > 0)
            {
                var node = q.Dequeue();

                if (node == marker && q.Count > 0)
                {
                    q.Enqueue(node);
                    level++;
                    continue;
                }

                if (level == k)
                {
                    Console.WriteLine(node.val);
                    continue;
                }

                if (node.left != null)
                    q.Enqueue(node.left);

                if(node.right != null)
                    q.Enqueue(node.right);
            }

        }

        private static void PrintNodesAtLevelDFS(TreeNode root, int k)
        {
            if (root == null)
                return;

            if (k == 0)
            {
                Console.WriteLine(root.val);
                return;
            }

            PrintNodesAtLevelDFS(root.left, k - 1);
            PrintNodesAtLevelDFS(root.right, k - 1);
        }
    }
}
