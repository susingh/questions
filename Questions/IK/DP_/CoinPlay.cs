using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.DP_
{
    class CoinPlay
    {
        public static int maxWin(int[] v)
        {
            //return maxWin(0, v.Length - 1, v);
            return maxWinDP(v);
        }

        private static int maxWin(int i, int j, int[] v)
        {
            if (i > j)
                return 0;

            int leftMove = v[i] + Math.Min(maxWin(i + 2, j, v), maxWin(i + 1, j - 1, v));
            int rightMove = v[j] + Math.Min(maxWin(i, j - 2, v), maxWin(i + 1, j - 1, v));

            return Math.Max(leftMove, rightMove);
        }

        private static int maxWinDP(int[] v)
        {
            int[,] dp = new int[v.Length + 2, v.Length + 2];

            for (int i = v.Length - 1; i >= 0; i--)
            {
                for (int j = 2; j < v.Length + 2; j++)
                {
                    if (i > j)
                        continue;

                    int left = v[i] + Math.Min(dp[i + 2, j], dp[i + 1, j - 1]);
                    int right = v[j] + Math.Min(dp[i + 1, j - 1], dp[i, j - 2]);
                    dp[i, j] = Math.Max(left, right);
                }
            }

            return dp[0, v.Length - 1];
        }
    }
}