using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.DP_
{
    class NStairs
    {
        public static int countWaysToClimb(int[] steps, int n)
        {
            return -1;
        }

        public static int countWaysToClimbRecurse(int i, int[] steps, int n)
        {
            if (i >= n)
                return 1;

            int ways = 0;
            foreach (int step in steps)
            {
                ways += countWaysToClimbRecurse(i + step, steps, n);
            }

            return ways;
        }

        public static int countWaysToClimbRecurse2(int[] steps, int n)
        {
            if (n == 0)
            {
                return 1;
            }

            if (n < 0)
            {
                return 0;
            }

            int ways = 0;
            foreach(var step in steps)
            {
                ways += countWaysToClimbRecurse2(steps, n - step);
            }

            return ways;
        }

        public static int countWaysToClimbDP2(int[] steps, int n)
        {
            int[] dp = new int[n + 1];
            dp[0] = 1;

            for (int i = 1; i < dp.Length; i++)
            {
                int ways = 0;
                foreach (var step in steps)
                {
                    if (i >= step)
                    {
                        ways += dp[i - step];
                    }
                }

                dp[i] = ways;
            }

            return dp[n];
        }


        public static int countWaysToClimbDP(int[] steps, int n)
        {
            int[] dp = new int[n + 1];
            dp[n] = 1;

            for (int i = n - 1; i >= 0; i--)
            {
                int ways = 0;
                foreach (int step in steps)
                {
                    if (i + step > n)
                    {
                        ways++;
                    }
                    else
                    {
                        ways += dp[i + step];
                    }
                }

                dp[i] = ways;
            }

            return dp[0];
        }
    }
}