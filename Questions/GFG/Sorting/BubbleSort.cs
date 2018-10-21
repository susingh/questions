using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.GFG.Sorting
{
    class BubbleSort
    {
        public static void Sort(int[] arr)
        {
            while(true)
            {
                bool hasSwapped = false;
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] < arr[i-1])
                    {
                        Swap(arr, i, i - 1);
                        hasSwapped = true;
                    }
                }

                if (!hasSwapped)
                {
                    break;
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
