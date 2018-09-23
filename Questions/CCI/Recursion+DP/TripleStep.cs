using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.CCI.Recursion_DP
{
    class TripleStep
    {
        public static int Ways(int n)
        {
            int[] steps = new int[] { 1, 2, 3 };
            //return Ways(n, steps);

            int[] table = new int[n+1];
            for (int i = 0; i < table.Length; i++)
            {
                table[i] = -1;
            }
            return WaysWithMemoization(n, steps, table);
        }

        private static int Ways(int n, int[] steps)
        {
            if (n < 0)
            {
                return 0;
            }

            if (n == 0)
            {
                return 1;
            }

            int totalWays = 0;
            foreach (var step in steps)
            {
                totalWays += Ways(n - step, steps);
            }

            return totalWays;
        }

        private static int WaysWithMemoization(int n, int[] steps, int[] table)
        {
            if (n < 0)
            {
                return 0;
            }

            if (n == 0)
            {
                return 1;
            }

            int totalWays = 0;
            if (table[n] != -1)
            {
                totalWays = table[n];
            }
            else
            {
                foreach (var step in steps)
                {
                    totalWays += WaysWithMemoization(n - step, steps, table);
                }
                table[n] = totalWays;
            }

            return totalWays;
        }
    }
}
