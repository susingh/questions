using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Sorting
{
    class SortedSets
    {
        /// <summary>
        /// O(max(m, n))
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        public static bool IsSubSet(int[] arr1, int[] arr2)
        {
            int[] big, small;

            if (arr1.Length >= arr2.Length)
            {
                big = arr1;
                small = arr2;
            }
            else
            {
                big = arr2;
                small = arr1;
            }

            int i = 0, j = 0;
            while (i < big.Length && j < small.Length)
            {
                if (big[i] == small[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    // move fwd in the bigger array
                    i++;
                }

            }

            return i == arr1.Length || j == arr2.Length;
        }

        private static bool IsSubSetMatches(int[] arr1, int[] arr2)
        {
            int matches = 0;
            int i = 0;
            int j = 0;

            while (i < arr1.Length && j < arr2.Length)
            {
                if (arr1[i] == arr2[j])
                {
                    j++;
                    i++;
                    matches++;
                }
                else if (arr1[i] < arr2[j])
                {
                    i++;
                }
                else
                    j++;
            }

            return matches == Math.Min(arr1.Length, arr2.Length);
        }

        /// <summary>
        /// T: O(max(m, n)), S: O(min(m.n))
        /// </summary>
        /// <param name="arr1"></param>
        /// <param name="arr2"></param>
        /// <returns></returns>
        private static bool IsSubset(int[] arr1, int[] arr2)
        {
            int[] big, small;

            if (arr1.Length >= arr2.Length)
            {
                big = arr1;
                small = arr2;
            }
            else
            {
                big = arr2;
                small = arr1;
            }

            HashSet<int> set = new HashSet<int>();
            foreach (var item in small)
            {
                set.Add(item);
            }

            int missing = set.Count;

            for (int i = 0; i < big.Length; i++)
            {
                if (set.Contains(big[i]))
                {
                    missing--;
                    if (missing == 0)
                        return true;
                }
            }

            return false;
        }

        private static bool IsSubsetBinarySearch(int[] arr1, int[] arr2)
        {
            int[] big, small;

            if (arr1.Length >= arr2.Length)
            {
                big = arr1;
                small = arr2;
            }
            else
            {
                big = arr2;
                small = arr1;
            }

            for (int i = 0; i < small.Length; i++)
            {
                if (!HasElement(big, small[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool HasElement(int[] arr, int elem)
        {
            // run binary search for element in the arr
            return true;
        }
    }
}
