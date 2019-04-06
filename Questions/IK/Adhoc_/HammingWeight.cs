using System;
using System.Collections.Generic;

namespace Questions.IK.Adhoc_
{
    class HammingWeight
    {
        public static int Weight(List<long> s)
        {
            //return WeightBF(s);
            // return WeightBK(s);
            return WeightDP(s);
        }

        private static int WeightBF(List<long> s)
        {
            int total = 0;

            foreach (var num in s)
            {
                long curr = num;
                int setBits = 0;

                while(curr > 0)
                {
                    if ((curr & 1) == 1)
                    {
                        setBits++;
                    }
                    curr = curr >> 1;
                }

                total += setBits;
            }

            return total;
        }

        /// <summary>
        /// Brian Kernighan’s method
        /// </summary>
        private static int WeightBK(List<long> s)
        {
            int total = 0;

            foreach (var num in s)
            {
                long curr = num;

                while (curr > 0)
                {
                    total++;
                    curr = curr & (curr - 1);
                }
            }

            return total;
        }

        private static int WeightDP(List<long> s)
        {
            int total = 0;
            int[] dp = new int[(int)Math.Pow(2, 8) + 1];

            dp[0] = 0;
            dp[1] = 1;

            for (int i = 2; i < dp.Length; i++)
            {
                dp[i] = (i & 1) + dp[i >> 1];
            }

            uint p1 = 0x000000FF;
            uint p2 = 0x0000FF00;
            uint p3 = 0x00FF0000;
            uint p4 = 0xFF000000;

            foreach (var num in s)
            {
                total += dp[(num & p1) >> 0];
                total += dp[(num & p2) >> 8];
                total += dp[(num & p3) >> 16];
                total += dp[(num & p4) >> 24];
            }

            return total;
        }
    }
}
