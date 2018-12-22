using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.GFG.String
{
    class ZigZag
    {
        public static void Convert(int[] arr)
        {
            ConvertSorting(arr);
        }

        private static void ConvertSorting(int[] arr)
        {
            Array.Sort(arr);

            bool isAsc = true;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                // item already in place
                if (isAsc && arr[i] < arr[i+1] || !isAsc && arr[i] > arr[i+1])
                {
                    isAsc = !isAsc;
                    continue;
                }
                else
                {
                    Swap(arr, i, i+1);
                    isAsc = !isAsc;
                }
            }
        }

        private static void Swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
    }
}
