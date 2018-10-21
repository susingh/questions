using System;

namespace Questions.IK.Sorting
{
    /*
     * Quick sort:
     * - In place sorting algo - no extra space required.
     * - Not stable (but can be made stable)
     * - Worst case O(n^2), but can be avoided by choosing random pivots.
     */
    class QuickSort
    {
        public static void Sort(int[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        private static void Sort(int[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivot = ChoosePivot(arr, start, end);
            int pi = Partition(arr, start, end, pivot);

            Sort(arr, start, pi - 1);
            Sort(arr, pi + 1, end);
        }

        private static void Swap(int[] arr, int a, int b)
        {
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }
        
        private static int ChoosePivot(int[] arr, int start, int end)
        {
            // Pick a random pivot to avoid worst case performance.
            var rand = new Random();
            return rand.Next(start, end);
        }

        private static int Partition(int[] arr, int start, int end, int pivot)
        {
            // After partition, the values on the left of the array will be smaller or equal to the partition.
            int pValue = arr[pivot];

            // Swap the last element with pValue
            Swap(arr, pivot, end);

            int i = start;
            int j = end - 1;

            while (i < j)
            {
                while (i <= end - 1 && arr[i] < pValue)
                    i++;

                while (j >= start && arr[j] > pValue)
                    j--;

                if (i < j)
                {
                    Swap(arr, i, j);
                    i++;
                    j--;
                }
            }

            // put the partition element back in place.
            Swap(arr, i, end);
            return i;
        }
    }
}
