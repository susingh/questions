using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Tree
{
    class TreeDriver : IQuestion
    {
        public void Run()
        {
            //throw new NotImplementedException();
            TreeNode root = new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3)
            };

            var sol
                // = IsBST.isBST(root);
                // = NumberOfBSTs.how_many_BSTs(3);
                // = KthSmallest.kth_smallest_element(new TreeNode)
                = UpsideDown.flipUpsideDown(root);

        }
    }
}
