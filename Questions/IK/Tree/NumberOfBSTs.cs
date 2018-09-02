namespace Questions.IK.Tree
{
    class NumberOfBSTs
    {
        public static long how_many_BSTs(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            long totalCount = 0;
            
            for (int i = 0; i < n - 1; i++)
            {
                int rightRemaining = i;
                int leftRemaining = n - 1 - rightRemaining;
                totalCount += how_many_BSTs(leftRemaining) * how_many_BSTs(rightRemaining);
            }

            //root.left = new TreeNode(0);
            //totalCount = how_many_BSTs(root.left, remaining - 1);

            //root.right = new TreeNode(0);
            //totalCount += how_many_BSTs(root.right, remaining - 1);

            //if (remaining == 2)
            //{
            //    totalCount++;
            //}
            //else if (remaining > 2)
            //{
            //    totalCount += how_many_BSTs(root.left, remaining - 2);
            //    totalCount += how_many_BSTs(root.right, remaining - 2);
            //}

            return totalCount;
        }
    }
}
