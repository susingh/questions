using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Adhoc_
{
    class MergeOverlappingIntervals
    {
        private class Compare : IComparer<int[]>
        {
            int IComparer<int[]>.Compare(int[] x, int[] y)
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
                    return +1;
                }
            }
        }

        public static int[][] GetMergedIntervals(int[][] inputArray)
        {
            List<int[]> result = new List<int[]>();
            MergedIntervals(inputArray, result);
            return result.ToArray();
        }


        private static void MergedIntervals(int[][] input, List<int[]> result)
        {
            Array.Sort(input, new Compare());

            for (int i = 0; i < input.Length; i++)
            {

            }
        }
    }
}
