using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.GFG.Sorting
{
    class HeapSort
    {
        public static void Sort(int[] arr)
        {
            // build a max the heap
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            // Remove one element from the root and re-heapify.
            for (int i = n -1; i >= 0; i--)
            {
                Swap(arr, 0, i);
                Heapify(arr, i, 0);
            }
        }

        private static void Heapify (int[] arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && arr[largest] < arr[left])
                largest = left;

            if (right < n && arr[largest] < arr[right])
                largest = right;

            if (largest != i)
            {
                Swap(arr, largest, i);
                
                // Ensure that the sub-tree continues to satisfy the max-heap property
                Heapify(arr, n, largest);
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
