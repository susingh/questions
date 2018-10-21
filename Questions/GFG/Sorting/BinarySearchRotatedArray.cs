using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.GFG.Sorting
{
    class BinarySearchRotatedArray
    {
        public static int Search(int[] arr, int x)
        {
            return Search(arr, 0, arr.Length - 1, x);
        }

        private static int Search(int[] arr, int l, int r, int x)
        {
            if (r >= l)
            {
                int mid = l + (r - l) / 2;

                if (arr[mid] == x)
                    return mid;

                // left side is sorted
                if (arr[l] <= arr[mid -1])
                {
                    if (arr[l] <= x && arr[mid - 1] >= x)
                    {
                        return Search(arr, l, mid - 1, x);
                    }
                    else
                    {
                        return Search(arr, mid + 1, r, x);
                    }
                }
                // right side must be sorted
                else
                {
                    if (arr[r] >= x && arr[mid + 1] <= x)
                    {
                        return Search(arr, mid + 1, r, x);
                    }
                    else
                    {
                        return Search(arr, l, mid - 1, x);
                    }
                }
            }

            return -1;
        }
    }
}
