using System;
using System.Collections.Generic;

namespace Questions.IK.Adhoc_
{
    class MergeOverappingIntervals
    {
        public static int[][] getMergedIntervals(int[][] inputArray)
        {
            List<int[]> result = new List<int[]>();
            getMergedIntervals(inputArray, result);
            return result.ToArray();
        }

        private class CustomCompare : IComparer<int[]>
        {
            public int Compare(int[] x, int[] y)
            {
                if (x[0] < y[0])
                {
                    return -1;
                }
                else if (x[0] == y[0])
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        private static void getMergedIntervals(int[][] inputArray, List<int[]> result)
        {
            Array.Sort(inputArray, new CustomCompare());
            result.Add(new int[] { inputArray[0][0], inputArray[0][1]});

            for (int i = 1; i < inputArray.Length; i++)
            {
                int[] last = result[result.Count - 1];
                int[] curr = inputArray[i];

                if (curr[0] >= last[0] && curr[0] <= last[1])
                {
                    if (curr[1] > last[1])
                    {
                        last[1] = curr[1];
                    }
                }
                else
                {
                    result.Add(new int[] { inputArray[i][0], inputArray[i][1] });
                }
            }
        }
    }
}
