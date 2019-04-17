using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Tree
{
    class ConstructTree
    {
        public static TreeNode ConstructBinaryTree(List<int> inorder, List<int> preorder)
        {
            return ConstructBinaryTree(inorder, 0, inorder.Count - 1, preorder, 0, preorder.Count - 1);
        }

        private static TreeNode ConstructBinaryTree(List<int> inorder, int iS, int iE, List<int> preorder, int pS, int pE)
        {
            if (iS > iE || pS > pE)
            {
                return null;
            }

            int rootVal = preorder[pS];
            TreeNode node = new TreeNode(rootVal);

            int i = iS;
            while (i <= iE)
            {
                if (rootVal == inorder[i])
                {
                    break;
                }

                i++;
            }

            int count = (i - iS + 1) - 1;

            node.left = ConstructBinaryTree(inorder, iS, i-1, preorder, pS+1, pS + count);
            node.right = ConstructBinaryTree(inorder, i+1, iE, preorder, pS + count + 1, pE);

            return node;
        }
    }
}
