using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.DP_
{
    class PathsInMatrix
    {
        public static int numberOfPaths(int[][] a)
        {
            // return numberOfPaths(a, 0, 0);
            return numberOfPathsDp(a);
        }

        private static int numberOfPathsDp(int[][] a)
        {
            int rows = a.Length;
            int cols = a[0].Length;

            int[,] dp = new int[rows + 1, cols + 1];
            dp[rows-1, cols-1] = 1;

            for (int i = rows - 1; i >= 0; i--)
            {
                for (int j = cols - 1; j >= 0; j--)
                {
                    if (i == rows - 1 && j == cols - 1)
                        continue;

                    if (a[i][j] == 0)
                    {
                        dp[i, j] = 0;
                    }
                    else
                    {
                        dp[i, j] = (dp[i + 1, j] + dp[i, j + 1]) % (10 ^ 9 + 7);
                    }
                }
            }

            return dp[0, 0];
        }
    }
}
