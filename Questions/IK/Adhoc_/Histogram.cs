using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Adhoc_
{
    class Histogram
    {
        public static long findMaxPossibleArea(long[] heights, int l, int r)
        {
            return findMaxPossibleAreaRecursive(heights, l, r).val;
        }

        /// <summary>
        /// T O(n^2) S O(1)
        /// </summary>
        /// <param name="heights"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private static long findMaxPossibleAreaBF(long[] heights, int l, int r)
        {
            long maxArea = long.MinValue;

            for (int i = l; i <= r; i++)
            {
                long leastHeight = long.MaxValue;
                for (int j = i; j <= r; j++)
                {
                    if (heights[j] < leastHeight)
                    {
                        leastHeight = heights[j];
                    }

                    long area = (j - i + 1) * leastHeight;

                    if (area > maxArea)
                    {
                        maxArea = area;
                    }
                }
            }

            return maxArea;
        }

        /// <summary>
        /// T O(nlogn)
        /// </summary>
        /// <param name="heights"></param>
        /// <param name="l"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        private static MaxSubArrayLong findMaxPossibleAreaRecursive(long[] heights, int l, int r)
        {
            if (l == r)
            {
                return new MaxSubArrayLong() { val = heights[l], start = l, end = r };
            }

            if (l > r)
            {
                return new MaxSubArrayLong();
            }

            int mid = l + (r - l) / 2;

            MaxSubArrayLong left = findMaxPossibleAreaRecursive(heights, l, mid - 1);
            MaxSubArrayLong right = findMaxPossibleAreaRecursive(heights, mid + 1, r);
            MaxSubArrayLong middle = GetMaxAreaMiddle(heights, l, r, mid);

            // find the max of left right and middle.f
            MaxSubArrayLong max = left.val < right.val ? right : left;
            max = max.val < middle.val ? middle : max;
            return max;
        }

        private static MaxSubArrayLong GetMaxAreaMiddle(long[] heights, int l, int r, int mid)
        {
            long leftMaxArea = 0;
            int max_start = mid;
            long leftLeastHeight = long.MaxValue;

            for (int i = mid - 1; i >= l; i--)
            {
                if (heights[i] < leftLeastHeight)
                {
                    leftLeastHeight = heights[i];
                }

                long area = ((mid - 1) - i + 1) * leftLeastHeight;
                if (area > leftMaxArea)
                {
                    max_start = i;
                    leftMaxArea = area;
                }
            }

            long rightMaxArea = 0;
            int max_end = mid;
            long rightLeastHeight = long.MaxValue;

            for (int i = mid + 1; i <= r; i++)
            {
                if (heights[i] < rightLeastHeight)
                {
                    rightLeastHeight = heights[i];
                }

                long area = (i - (mid + 1) + 1) * rightLeastHeight;
                if (area > rightMaxArea)
                {
                    max_end = i;
                    rightMaxArea = area;
                }
            }

            // find least height from max_start to max_end
            long leastHeight = long.MaxValue;
            for (int i = max_start; i <= max_end; i++)
            {
                if (heights[i] < leastHeight)
                {
                    leastHeight = heights[i];
                }
            }

            long totalArea = leastHeight * (max_end - max_start + 1);

            return new MaxSubArrayLong() { val = totalArea, start = max_start, end = max_end };
        }
    }
}
