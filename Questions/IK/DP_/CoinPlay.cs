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
            return maxWin(0, v.Length - 1, v);
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
            int[,] dp = new int[v.Length, v.Length];
            for (int i = 0; i < v.Length; i++)
            {
                for (int j = 0; j < v.Length; j++)
                {
                    if (i > j)
                    {
                        dp[i, j] = 0;
                    }
                }
            }

            for (int i = 0; i < v.Length; i++)
            {
                for (int j = 0; j < v.Length; j++)
                {
                    int leftMove = v[i] + Math.Min(dp[i + 2, j], dp[i + 1, j - 1]);
                    int rightMove = v[j] + Math.Min(dp[i, j - 2], dp[i + 1, j - 1]);

                    dp[i, j] = Math.Max(leftMove, rightMove);
                }
            }

            return dp[0, v.Length - 1];
        }
    }
}