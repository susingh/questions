namespace Questions.IK.Recursion
{
    class TestForTie
    {
        public static bool IsTie(int[] arr)
        {
            int sum = 0;
            foreach (var item in arr)
                sum += item;

            if (sum % 2 != 0)
                return false;

            return IsSubSetSum(arr, 0, sum / 2);
        }

        private static bool IsSubSetSum(int[] arr, int i, int sum)
        {
            if (i == arr.Length)
                return false;
            
            if (sum == 0)
                return true;

            if (sum < 0)
                return false;

            return IsSubSetSum(arr, i + 1, sum) || IsSubSetSum(arr, i + 1, sum - arr[i]);
        }

        private static bool IsSubsetSumDp(int[] arr, int sum)
        {
            bool[,] dp = new bool[arr.Length + 1, sum + 1];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i, 0] = true;
            }

            for (int i = 0; i < sum; i++)
            {
                dp[arr.Length, i] = false;
            }

            for (int i = arr.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < sum; j++)
                {
                    dp[i, j] = dp[i + 1, j] || dp[i + 1, j - arr[i]];
                }
            }

            return dp[0, sum];
        }
    }
}
