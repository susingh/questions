using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.DP_
{
    class MaxPath
    {
        public static int Max_Path(int[,] arr)
        {
            //return maxPath(arr, 0, 0);

            int r = arr.GetLength(0);
            int c = arr.GetLength(1);

            int[,] result = new int[r+1, c+1];
            for (int i = 0; i <= r; i++)
            {
                for (int j = 0; j <= c; j++)
                {
                    result[i, j] = int.MinValue;
                }
            }

            return maxPathMemoization(arr, result, 0, 0);

            //return maxPathDP(arr);
        }

        private static int maxPath(int[,] arr, int i, int j)
        {
            // base condition
            int r = arr.GetLength(0);
            int c = arr.GetLength(1);
            if (i == r - 1 && j == c - 1)
            {
                return arr[i, j];
            }

            // guards
            if (i == r || j == c)
            {
                return 0;
            }

            // recurse
            int downMax = maxPath(arr, i, j + 1);
            int rightMax = maxPath(arr, i + 1, j);

            return arr[i, j] + Math.Max(rightMax, downMax);
        }

        private static int maxPathMemoization(int[,] arr, int[,] result, int i, int j)
        {
            // base condition
            int r = arr.GetLength(0);
            int c = arr.GetLength(1);

            if (i == r - 1 && j == c - 1)
            {
                return arr[i, j];
            }

            // guards
            if (i == r || j == c)
            {
                return 0;
            }

            // recurse
            int rightMax = int.MinValue;
            if (result[i, j + 1] != int.MinValue)
            {
                rightMax = result[i, j + 1];
            }
            else
            {
                rightMax = maxPathMemoization(arr, result, i, j + 1);
                result[i, j + 1] = rightMax;
            }

            int downMax = int.MinValue;
            if (result[i + 1, j] != int.MinValue)
            {
                downMax = result[i + 1, j];
            }
            else
            {
                downMax = maxPathMemoization(arr, result, i + 1, j);
                result[i + 1, j] = downMax;
            }

            return arr[i, j] + Math.Max(downMax, rightMax);
        }

        private static int maxPathDP(int[,] arr)
        {
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);

            int[,] dpTable = new int[n + 1, m + 1];

            for (int r = 0; r <= n; r++)
                dpTable[r, m] = 0;

            for (int c = 0; c <= m; c++)
                dpTable[n, c] = 0;

            dpTable[n - 1, m - 1] = arr[n - 1, m - 1];

            for (int i = n - 1; i >= 0; i--)
            {
                for (int j = m - 1; j >= 0; j--)
                {
                    dpTable[i, j] = arr[i, j] + Math.Max(dpTable[i, j + 1], dpTable[i + 1, j]);
                }
            }

            return dpTable[0, 0];
        }

        private static void RecoverMaxPath(int[,] arr, int[,] dpTable)
        {
            int c = 0, r = 0;
            int n = arr.GetLength(0);
            int m = arr.GetLength(1);

            Console.WriteLine($"{r}{c}");

            while (r < n && c < m)
            {
                if (dpTable[r + 1, c] > dpTable[r, c + 1])
                {
                    r = r + 1;
                }
                else
                {
                    c = c + 1;
                }

                Console.WriteLine($"{r}{c}");
            }
        }
    }
}
