using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Recursion
{
    class TargetSum
    {
        public static bool check_if_sum_possible(long[] arr, long k)
        {
            return check_if_sum_possible(arr, 0, k, false);
        }

        private static bool check_if_sum_possible(long[] input, int i, long sum, bool hasConsideredElements)
        {
            if (sum == 0 && hasConsideredElements)
            {
                return true;
            }

            if (i == input.Length)
            {
                return false;
            }

            return check_if_sum_possible(input, i + 1, sum, false) || check_if_sum_possible(input, i + 1, sum - input[i], true);
        }
    }
}
