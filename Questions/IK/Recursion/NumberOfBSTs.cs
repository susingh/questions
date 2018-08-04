namespace Questions.IK.Recursion
{
    class NumberOfBSTs
    {
        public static long how_many_BSTs(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            TreeNode root = new TreeNode(0);
            return how_many_BSTs(root, n-1);
        }
        
        private static long how_many_BSTs(TreeNode root, int remaining)
        {
            if (remaining == 1)
            {
                return 2;
            }

            long totalCount = 0;

            root.left = new TreeNode(0);
            totalCount = how_many_BSTs(root.left, remaining - 1);

            root.right = new TreeNode(0);
            totalCount += how_many_BSTs(root.right, remaining - 1);

            if (remaining == 2)
            {
                totalCount++;
            }
            else if (remaining > 2)
            {
                totalCount += how_many_BSTs(root.left, remaining - 2);
                totalCount += how_many_BSTs(root.right, remaining - 2);
            }

            return totalCount;
        }
    }
}
