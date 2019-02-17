using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Tree
{
    class PostOrderWithoutRecursion
    {
        public static void postorderTraversal(TreeNode root)
        {
            if (root == null)
                return;

            Stack<TreeNode> s = new Stack<TreeNode>();
            s.Push(root);

            while (s.Count != 0)
            {
                var curr = s.Peek();

                // left node
                if (curr.left == null && curr.right == null)
                {
                    s.Pop();
                    Console.Write(curr.val);

                    if (s.Count != 0)
                    {
                        Console.Write(" ");
                    }
                }
                else
                {
                    if (curr.right != null)
                    {
                        s.Push(curr.right);
                        curr.right = null;
                    }

                    if (curr.left != null)
                    {
                        s.Push(curr.left);
                        curr.left = null;
                    }
                }
            }
        }
    }
}
