﻿using Questions.IK.Sorting;
using System.Collections;

namespace Questions.IK
{
    /*
        quick sort - use when space is constaint
        merge sort - better on disk, locality of reference, takes extra space
     */
    public class SortingDriver : IQuestion
    {
        public static void Swap<T>(T[] arr, int a, int b)
        {
            T temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        public void Run()
        {
            //var result = dutch_flag_sort("GR");

            int[] arr = { 1, 5, 4, 4, 2 };

            int[][] arr2d =
                {
                    new int[]{4,4,7,11,13,20,26,34},
new int[]{0,8,10,19,23,27,34,41},
new int[]{5,7,7,7,12,19,25,26},
new int[]{9,12,19,27,33,35,39,46},
new int[]{0,3,10,18,18,22,24,33},
new int[]{9,12,20,21,30,35,35,42},
new int[]{7,8,12,12,21,24,33,42},
new int[]{7,8,11,18,18,21,23,29},
new int[]{7,8,14,15,23,30,30,35},
new int[]{4,5,11,12,16,17,18,20}
                };

            //var result = merger_first_into_second(arr1, arr2);

            var sol
                //= GroupNumbers.solve(arr);
                // = TopK.solve(arr, 2);
                = MergeKSortedArrays.mergeArrays(arr2d);
        }
    }
}