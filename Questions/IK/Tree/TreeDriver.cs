namespace Questions.IK.Tree
{
    class TreeDriver : IQuestion
    {
        public void Run()
        {
            TreeNode root = new TreeNode(0)
            {
                left = new TreeNode(1)
                {
                    //left = new TreeNode(1),
                    //right = new TreeNode(3)
                },
                right = new TreeNode(0)
                {
                    left = new TreeNode(1)
                    {
                        left = new TreeNode(1),
                        right = new TreeNode(1)
                    },
                    right = new TreeNode(0)
                }
            };

            var sol
                 // = IsBST.isBST(root);
                 // = NumberOfBSTs.how_many_BSTs(3);
                 // = KthSmallest.kth_smallest_element(new TreeNode)
                 // = UpsideDown.flipUpsideDown(root);
                 // = LargestBST.FindLargestBST(root);
                 // = Serialize.SerializeBT(root);
                 = UnivalTree.FindUnivalTrees(root);

            //var node = Serialize.DeserializeCompleteBT(sol);

        }
    }
}
