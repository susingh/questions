using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Adhoc_
{
    class MaxSubsetSum
    {
        public static MaxSubArray MaxSumSubArray(int[] arr)
        {
            //return MaxSumSubArrayBF(arr);
            //return MaxSumSubArrayBFImproved(arr);
            return MaxSumSubArrayRecursion(arr, 0, arr.Length - 1);
            //return MaxSumSubArrayLinear(arr);
        }

        /// <summary>
        /// T: O(n^3) S: O(1)
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static MaxSubArray MaxSumSubArrayBF(int[] arr)
        {
            MaxSubArray result = new MaxSubArray();

            for (int start = 0; start < arr.Length; start++)
            {
                for (int end = start; end < arr.Length; end++)
                {
                    int value = 0;
                    for (int i = start; i <= end; i++)
                    {
                        value += arr[i];
                    }

                    if (value > result.val)
                    {
                        result.start = start;
                        result.end = end;
                        result.val = value;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// T: O(n^2) S: O(1)
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static MaxSubArray MaxSumSubArrayBFImproved(int[] arr)
        {
            MaxSubArray result = new MaxSubArray();

            for (int start = 0; start < arr.Length; start++)
            {
                int cumSum = 0;

                for (int end = start; end < arr.Length; end++)
                {
                    cumSum += arr[end];

                    if (cumSum > result.val)
                    {
                        result.start = start;
                        result.end = end;
                        result.val = cumSum;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// T (nlogn) S O(1) 
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private static MaxSubArray MaxSumSubArrayRecursion(int[] arr, int start, int end)
        {
            if (start == end)
            {
                return new MaxSubArray() { start = start, end = end, val = arr[start] };
            }

            if (start > end)
            {
                return new MaxSubArray();
            }

            int mid = start + (end - start) / 2;

            MaxSubArray left = MaxSumSubArrayRecursion(arr, start, mid - 1);
            MaxSubArray right = MaxSumSubArrayRecursion(arr, mid + 1, end);
            MaxSubArray middle = GetMaxMiddle(arr, start, end, mid);

            // find the max of left right and middle.f
            MaxSubArray max = left.val < right.val ? right : left;
            max = max.val < middle.val ? middle : max;

            return max;
        }

        private static MaxSubArray GetMaxMiddle(int[] arr, int start, int end, int mid)
        {
            int leftSum = 0;
            int leftMaxSum = 0;
            int leftMaxIndex = mid;

            for (int i = mid - 1; i >= start; i--)
            {
                leftSum += arr[i];
               
                if (leftSum > leftMaxSum)
                {
                    leftMaxSum = leftSum;
                    leftMaxIndex = i;
                }
            }

            int rightSum = 0;
            int rightMaxSum = 0;
            int rightMaxIndex = mid;

            for (int i = mid + 1; i <= end; i++)
            {
                rightSum += arr[i];

                if (rightSum > rightMaxSum)
                {
                    rightMaxSum = rightSum;
                    rightMaxIndex = i;
                }
            }

            return new MaxSubArray()
            {
                val = leftMaxSum + rightMaxSum + arr[mid],
                start = leftMaxIndex,
                end = rightMaxIndex
            };
        }

        /// <summary>
        /// T O(n) S O(1)
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        private static MaxSubArray MaxSumSubArrayLinear(int[] arr)
        {
            int cumSum = 0;
            int maxSum = 0;

            int currStart = -1;
            int maxStart = -1;
            int maxEnd = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                cumSum += arr[i];

                if (cumSum < 0)
                {
                    currStart = i + 1;
                    maxSum = 0;
                    cumSum = 0;
                }

                if (cumSum > maxSum)
                {
                    maxEnd = i;
                    maxSum = cumSum;
                    maxStart = currStart;
                }

            }

            return new MaxSubArray { start = maxStart, end = maxEnd, val = maxSum };
        }
    }
}
