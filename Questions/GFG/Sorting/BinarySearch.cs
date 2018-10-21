using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.GFG.Sorting
{
    class BinarySearch
    {
        public static int Search(int[] arr, int x)
        {
            if (x < arr[0] || x > arr[arr.Length - 1])
                return -1;

            return Search(arr, 0, arr.Length - 1, x);
        }

        private static int Search(int[] arr, int l, int r, int x)
        {
            if (r >= l)
            {
                int mid = l + (r - l) / 2;

                if (arr[mid] == x)
                    return mid;
                else if (arr[mid] < x)
                {
                    return Search(arr, mid + 1, r, x);
                }
                else
                    return Search(arr, l, mid - 1, x);
            }

            return -1;
        }
    }
}
