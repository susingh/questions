using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.LinkedList
{
    public class MaxNumberInSlidingWindow
    {
        public static int[] max_in_sliding_window(int[] arr, int w)
        {
            int totalWindows = arr.Length - w + 1;
            int[] result = new int[totalWindows];

            int start = 0;
            int end = start + w -1;

            result[0] = GetMax(arr, start, end);

            for (int i = 1; i < totalWindows; i++)
            {
                start = i;
                end = i + w - 1;
                int previousMax = result[i - 1];

                if (arr[end] >= previousMax)
                {
                    // incoming value is more than previous max
                    result[i] = arr[end];
                }
                else if (arr[i - 1] != previousMax && arr[end] < previousMax)
                {
                    // incoming number is smaller than previous max and previous max was not removed
                    result[i] = previousMax;
                }
                else
                {
                    // previous max was removed, calculate the new max;
                    result[i] = GetMax(arr, start, end);
                }
            }

            return result;
        }

        static int GetMax(int[] arr, int start, int end)
        {
            int max = int.MinValue;
            for (int i = start; i <= end; i++)
            {
                max = Math.Max(max, arr[i]);
            }

            return max;
        }
    }
}
