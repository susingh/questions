using System;
using System.Collections.Generic;

namespace Questions.IK
{

    class DP : IQuestion
    {
        int RopeCut(int length)
        {
            int maxValue = length;

            for (int i = 1; i < length; i++)
            {
                int temp = RopeCut(length - i);
                maxValue = Math.Max(i * temp, maxValue);
            }

            return maxValue;
        }

        int RopeCutDP(int ropeLength)
        {
            int[] dpTable = new int[ropeLength + 1];
            dpTable[0] = 0;

            for (int len = 0; len <= ropeLength; len++)
            {
                int maxValue = len;

                for (int j = 1; j < ropeLength; j++)
                {
                    int temp = dpTable[ropeLength - j];
                    maxValue = Math.Max(j * temp, maxValue);
                }
            }

            return dpTable[ropeLength];
        }

        int RodCut(int length, int[] price)
        {
            int maxValue = price[length];

            for (int i = 1; i < length; i++)
            {
                int temp = RodCut(length - i, price);
                maxValue = Math.Max(price[i] + temp, maxValue);
            }

            return maxValue;
        }

        int RodCutDp(int rodLength, int[] price)
        {
            int[] dptable = new int[rodLength + 1];

            for (int len = 0; len <= rodLength; len++)
            {
                int maxValue = price[len];

                for (int i = 1; len < rodLength; len++)
                {
                    int temp = dptable[len - i];
                    maxValue = Math.Max(price[len] + temp, maxValue);
                }

            }

            return dptable[rodLength];
        }

        static int countWaysToClimb(int[] steps, int n)
        {
            if (n == 0)
            {
                return 0;
            }

            int paths = 0;

            for (int i = 0; i < steps.Length; i++)
            {
                if (n < steps[i]) continue;

                if (n == steps[i])
                {
                    paths++;
                }
                else
                {
                    paths += countWaysToClimb(steps, n - steps[i]);
                }
            }

            return paths;
        }
        
        static int countWaysToClimbDP(int[] steps, int n)
        {
            int[] dptable = new int[n + 1];
            dptable[0] = 0;

            for (int len = 1; len <= n; len++)
            {
                int paths = 0;

                for (int i = 0; i < steps.Length; i++)
                {
                    if (len < steps[i]) continue;

                    if (len == steps[i])
                    {
                        paths++;
                    }
                    else
                    {
                        paths += dptable[len - steps[i]];
                    }
                }

                dptable[len] = paths;
            }

            return dptable[n];
        }

        static void makeChange(int C, int[] intDenominations)
        {
            int[] dpTable = makeChangeDP(C, intDenominations);

            int[] paths = new int[dpTable.Length];
            var result = new HashSet<string>();
            FindCoins(dpTable, C, dpTable[C], intDenominations, paths, 0, result);
            //PrintCoins(result);
            
        }


        static void FindCoins(int[] dptable, int index, int remainingCoins, int[] denominations, int[] arr, int curr, HashSet<string> result)
        {
            if (index == 0 && remainingCoins == 0)
            {
                AddToResult(arr, curr - 1, result);
                return;
            }
            else if (remainingCoins == 0)
            {
                return;
            }

            foreach (var coin in denominations)
            {
                int newIndex = index - coin;
                if (newIndex >= 0 && dptable[newIndex] == remainingCoins - 1)
                {
                    arr[curr] = coin;
                    FindCoins(dptable, index - coin, remainingCoins - 1, denominations, arr, curr + 1, result);
                }
            }
        }

        private static void AddToResult(int[] arr, int curr, HashSet<string> result)
        {
            Array.Sort(arr, 0, curr + 1);
            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            for (int i = 0; i <= curr; i++)
            {
                builder.Append(arr[i]);

                if (i < curr)
                {
                    builder.Append(",");
                }
            }

            result.Add(builder.ToString());
        }

        static int[] makeChangeDP(int c, int[] denominations)
        {
            int[] dpTable = new int[c + 1];
            dpTable[0] = 0;

            for (int sum = 1; sum <= c; sum++)
            {
                int minCoins = int.MaxValue;

                for (int i = 0; i < denominations.Length; i++)
                {
                    if (denominations[i] > sum) continue;

                    int temp = dpTable[sum - denominations[i]];
                    if (temp == int.MaxValue) continue;
                    minCoins = Math.Min(minCoins, 1 + temp);

                }

                dpTable[sum] = minCoins;
            }

            return dpTable;
        }

        static int makeChangeInt(int c, int[] denominations)
        {
            if (c == 0)
            {
                return 0;
            }

            int minCoins = int.MaxValue;

            for (int i = 0; i < denominations.Length; i++)
            {
                if (denominations[i] > c) continue;

                int temp = makeChangeInt(c - denominations[i], denominations);
                if (temp == int.MaxValue) continue;
                minCoins = Math.Min(minCoins, 1 + temp);

            }

            return minCoins;
        }

        static void NthFibonacci(int n)
        {
            var result = FibonacciDP(n);
            Console.WriteLine(result);
        }

        static int Fibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            else if (n == 1)
            {
                return 1;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        static int FibonacciDP(int n)
        {
            int[] dptable = new int[n + 1];
            dptable[0] = 0;
            dptable[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                dptable[i] = dptable[i-1] + dptable[i - 2];
            }

            return dptable[n];
        }

        static long max_product_from_cut_pieces(int n)
        {
            //return CurTheRope(n);
            return CutTheRopeDP(n);

        }

        static long CurTheRope(int length)
        {
            long maxValue = length;

            for (int i = 1; i < length; i++)
            {
                if (length < i) continue;
                long temp = CurTheRope(length - i);
                maxValue = Math.Max(i * temp, maxValue);
            }

            return maxValue;
        }

        static long CutTheRopeDP(int ropeLength)
        {
            long[] dpTable = new long[ropeLength + 1];

            dpTable[0] = 0;
            dpTable[1] = 0;

            for (int len = 2; len <= ropeLength; len++)
            {
                long maxValue = len - 1;

                for (int j = 1; j < len; j++)
                {
                    long temp = dpTable[len - j];
                    maxValue = Math.Max(j * temp, maxValue);
                }

                dpTable[len] = maxValue;
            }

            return dpTable[ropeLength];
        }

        static int numberOfPaths(int[][] a)
        {
           //return numberOfPaths(a, 0, 0);
           return numberOfPathsDP(a);
        }

        static int numberOfPaths(int[][] a, int r, int c)
        {
            int rows = a.Length;
            int columns = a[0].Length;

            if (r == rows || c == columns)
            {
                return 0;
            }

            if ((a[r][c]) == 0)
            {
                return 0;
            }

            if (r == rows - 1 && c == columns - 1)
            {
                return 1;
            }

            return numberOfPaths(a, r + 1, c) + numberOfPaths(a, r, c+1);
        }

        static int numberOfPathsDP(int[][] a)
        {
            int rows = a.Length;
            int columns = a[0].Length;

            int[,] dptable = new int[rows + 1, columns + 1];

            for (int i = 0; i <= rows; i++)
            {
                dptable[i, columns] = 0;
            }

            for (int j = 0; j <= columns; j++)
            {
                dptable[rows, j] = 0;
            }

            for (int i = 0; i < rows; i++)
            {
                dptable[i, columns - 1] = a[i][columns - 1];
            }

            for (int j = 0; j < columns; j++)
            {
                dptable[rows - 1, j] = a[rows-1][j];
            }

            for (int i = rows - 2; i >= 0; i--)
            {
                for (int j = columns - 2; j >= 0; j--)
                {
                    if (a[i][j] == 0) continue;
                    dptable[i, j] = dptable[i + 1, j] + dptable[i, j + 1];
                }
            }

            return dptable[0, 0];

        }


        public void Run()
        {
            int[,] grid = new int[2, 2] { { 4, 8 }, { 1, 3 } };

            //var result = maxPath(grid);

            //var result = countWaysToClimbDP(new int[] { 2, 3 }, 7);
            //makeChange(10, new int[] { 4, 2, 3, 5, 6 });
            //NthFibonacci(9);
            //var result = max_product_from_cut_pieces(4);

            int[][] arr = new int[][]
            {
                new int[] { 1, 1, 1, 1, 1, 0, 0, 1 ,0, 1, },
                new int[] { 1, 1, 1, 1, 0, 0, 1, 0, 1, 0, },
                new int[] { 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, },
                new int[] { 1, 1, 0, 1, 1, 1, 1, 0, 1, 0 },
                new int[] { 1, 1, 0 ,1 ,0 ,1 ,0 ,1 ,0 ,1 },

                new int[] {1, 1, 1, 1, 1 ,1 ,1 ,1 ,1 ,1 },
                new int[] {1, 1, 0 ,1, 1 ,0 ,1 ,1 ,0 ,1 },
                new int[] { 1 ,1 ,0 ,0 ,1 ,1 ,0 ,1 ,0 ,1},
                new int[] {0, 1 ,1 ,1, 1, 1, 1 ,1 ,1 ,1 },
                new int[] { 1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 ,1 },
            };

            var result = numberOfPaths(arr);

        }
    }

}
