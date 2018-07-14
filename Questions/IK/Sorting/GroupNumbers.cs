using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Sorting
{
    class GroupNumbers
    {
        public static int[] solve(int[] arr)
        {
            if (arr.Length == 1)
            {
                return arr;
            }

            int i = 0;
            int j = arr.Length - 1;

            while (i < j)
            {
                while (i < arr.Length && arr[i] % 2 == 0)
                    i++;

                while (j >= 0 && arr[j] % 2 == 1)
                    j--;

                if (i < j)
                {
                    SortingDriver.Swap(arr, i, j);
                    i++;
                    j--;
                }
            }


            return arr;
        }
    }
}
