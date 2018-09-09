namespace Questions.IK.Tree
{
    class NumberOfBSTs
    {
        public static long how_many_BSTs(int n)
        {
            // a tree with 0 nodes is an empty tree, just like an empty set
            if (n == 0)
            {
                return 1;
            }

            // a tree with a single root node.
            if (n == 1)
            {
                return 1;
            }

            // pick a root from n nodes

            for (int i = 0; i < n; i++)
            {
                // i is the root
                // find possibilities in the left subr
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
