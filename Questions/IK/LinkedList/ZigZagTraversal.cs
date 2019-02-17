using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.LinkedList
{
    class ZigZagTraversal
    {
        private Stack<TreeNode> one = new Stack<TreeNode>();
        private Stack<TreeNode> two = new Stack<TreeNode>();

        public void Traverse(TreeNode root)
        {
            if (root == null) return;
            
            int level = 1;
            Stack<TreeNode> curr = GetStack(level);
            while (curr.Count != 0)
            {
                var node = curr.Pop();

                Console.Write($"{node.val} ");

                var otherStack = GetOtherStack(level);

                if (node.left != null) otherStack.Push(node.left);
                if (node.right != null) otherStack.Push(node.right);

                if (curr.Count == 0)
                {
                    level++;
                    curr = GetStack(level);
                }
            }
        }

        private Stack<TreeNode> GetStack(int i)
        {
            return (i % 2 == 0) ? two : one; 
        }

        private Stack<TreeNode> GetOtherStack(int i)
        {
            return (i % 2 == 0) ? one : two;
        }
    }
}
