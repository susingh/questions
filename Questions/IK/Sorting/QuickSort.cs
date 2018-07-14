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
        void Sort(int[] arr)
        {
            Sort(arr, 0, arr.Length - 1);
        }

        void Sort(int[] arr, int start, int end)
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


        private int ChoosePivot(int[] arr, int start, int end)
        {
            // choose a random pivot to avoid hitting the worst case.
            return start;
        }

        private int Partition(int[] arr, int start, int end, int pivot)
        {
            // After partition, the values on the left of the array will be smaller or equal to the partition
            int pValue = arr[pivot];
            int le_count = 0;
            for (int i = start; i <= end; i++)
            {
                if (arr[i] <= pValue)
                {
                    le_count++;
                }
            }

            int[] output = new int[end - start + 1];
            output[le_count - 1] = pValue;

            int le_index = 0;
            int ge_index = le_count;

            for (int i = start; i <= end; i++)
            {
                if (i == pivot)
                {
                    continue;
                }
                else if (arr[i] <= pValue)
                {
                    output[le_index++] = arr[i];
                }
                else
                {
                    output[ge_index++] = arr[i];
                }
            }

            return le_count - 1;
        }
    }
}
