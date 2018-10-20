using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Sorting
{
    class MergeSort
    {
        public static int[] Sort(int[] arr)
        {
            if (arr == null)
            {
                return null;
            }

            int[] newArr = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                newArr[i] = arr[i];
            }

            Sort(newArr, 0, newArr.Length - 1);
            return newArr;
        }

        private static void Sort(int[] arr, int start, int end)
        {
            if (start >= end) return;

            int mid = start + (end - start) / 2;
            Sort(arr, start, mid);
            Sort(arr, mid + 1, end);
            Merge(arr, start, mid, end);
        }

        private static void Merge(int[] arr, int start, int mid, int end)
        {
            int leftStart = start;
            int rightStart = mid + 1;

            //int n1 = mid - start + 1;
            //int n2 = end - (mid + 1);

            //int[] l = new int[n1];
            //int[] r = new int[n2];

            //Copy(arr, start, mid, l);
            //Copy(arr, mid + 1, end, r);

            int[] result = new int[end - start + 1];

            //int i = 0, j = 0, k = start;
            //while (i < n1 && j < n2)
            //{
            //    if (l[i] <= r[j])
            //    {
            //        arr[k++] = l[i++];
            //    }
            //    else
            //    {
            //        arr[k++] = r[j++];
            //    }
            //}

            int resultStart = 0;
            while (leftStart <= mid && rightStart <= end)
            {
                if (arr[leftStart] <= arr[rightStart])
                {
                    result[resultStart++] = arr[leftStart++];
                }
                else
                {
                    result[resultStart++] = arr[rightStart++];
                }
            }

            while (leftStart <= mid)
            {
                result[resultStart++] = arr[leftStart++];
            }

            while (rightStart <= end)
            {
                result[resultStart++] = arr[rightStart++];
            }

            //while (i < n1)
            //{
            //    arr[k++] = l[i++];
            //}

            //while (j < n2)
            //{
            //    arr[k++] = r[j++];
            //}

            for (int i = 0; i < result.Length; i++)
            {
                arr[start + i] = result[i];
            }
        }

        void Copy(int[] original, int start, int end, int[] newArr)
        { }

    }
}
