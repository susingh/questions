using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.DP_
{
    class Knapsack
    {
        public static int FindMaxValue(int[] values, int[] weights, int maxWeight)
        {
            return FindMaxValue(values, weights, 0, maxWeight);
        }

        private static int FindMaxValue(int[] values, int[] weights, int i, int weight)
        {
            if (weight <= 0 || i == values.Length)
            {
                return 0;
            }

            return Math.Max(
                FindMaxValue(values, weights, i + 1, weight), 
                values[i] + FindMaxValue(values, weights, i + 1, weight - weights[i])
                );
        }

    }
}
