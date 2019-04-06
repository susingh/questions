using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Adhoc_
{
    class MinRotatedSortedArray
    {
        public static int FindMin(int[] arr)
        {
            int l = 0;
            int r = arr.Length - 1;
            int min = arr[0];

            while (l < arr.Length && r >= 0)
            {
                int mid = (r - l) / 2;

                //if (arr[mid] < )
            }

            return min;
        }
    }
}