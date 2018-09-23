using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.DP_
{
    class Robbery
    {
        public static int maxStolenValue(int[] values)
        {
            //return maxStolenValueRecursive(values);
            // return maxStolenValueRecursiveMemoization(values);
            return maxStolenValueDP(values);
        }

        private static int maxStolenValueRecursiveMemoization(int[] values)
        {
            int maxValue = int.MinValue;
            Dictionary<int, int> maxValues = new Dictionary<int, int>();
            for (int i = 0; i < values.Length; i++)
            {
                int value = maxStolenValueRecursiveMemoization(values, maxValues, i);
                maxValue = Math.Max(maxValue, value);
            }
            return maxValue;
        }

        private static int maxStolenValueRecursive(int[] values)
        {
            int maxValue = int.MinValue;
            for (int i = 0; i < values.Length; i++)
            {
                int value = maxStolenValueRecursive(values, i);
                maxValue = Math.Max(maxValue, value);
            }
            return maxValue;
        }

        private static int maxStolenValueRecursive(int[] values, int i)
        {
            if (i >= values.Length)
            {
                return 0;
            }

            // skip the adjacent house on the right
            int rightIndex = i + 2;
            
            int maxRightValue = 0;
            while (rightIndex < values.Length)
            {
                Console.WriteLine("Calculating max right value for index " + rightIndex);
                int rightValue = maxStolenValueRecursive(values, rightIndex);
                rightIndex++;
                maxRightValue = Math.Max(maxRightValue, rightValue);
            }

            return maxRightValue + values[i];
        }

        private static int maxStolenValueDP(int[] values)
        {
            int[] dpTable = new int[values.Length];
            dpTable[values.Length - 1] = values[values.Length - 1];

            for (int i = dpTable.Length - 2; i >= 0; i--)
            {
                int rightIndex = i + 2;
                int maxRightValue = 0;
                while (rightIndex < values.Length)
                {
                    int rightValue = dpTable[rightIndex];
                    maxRightValue = Math.Max(maxRightValue, rightValue);
                    rightIndex++;
                }

                dpTable[i] = maxRightValue + values[i];
            }

            int maxValue = 0;
            foreach (var value in dpTable)
            {
                maxValue = Math.Max(maxValue, value);
            }

            return maxValue;
        }

        private static int maxStolenValueRecursiveMemoization(int[] values, IDictionary<int, int> maxValues, int i)
        {
            if (i >= values.Length)
            {
                return 0;
            }

            // skip the adjacent house on the right
            int rightIndex = i + 2;

            int maxRightValue = 0;
            while (rightIndex < values.Length)
            {
                int rightValue = 0;
                
                if (maxValues.ContainsKey(rightIndex))
                {
                    rightValue = maxValues[rightIndex];
                }
                else
                {
                    Console.WriteLine("Calculating max right value for index " + rightIndex);
                    rightValue = maxStolenValueRecursiveMemoization(values, maxValues, rightIndex);
                    maxValues[rightIndex] = rightValue;
                }
                
                maxRightValue = Math.Max(maxRightValue, rightValue);
                rightIndex++;
            }

            return maxRightValue + values[i];
        }
    }
}
