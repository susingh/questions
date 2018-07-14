using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Sorting
{
    class MergeSort
    {
        void Sort(int[] arr)
        {
            if (arr == null)
            {
                return;
            }

            Sort(arr, 0, arr.Length - 1);
        }

        void Sort(int[] arr, int start, int end)
        {
            if (start >= end) return;

            int mid = start + (end - start) / 2;
            Sort(arr, start, mid);
            Sort(arr, mid + 1, end);
            Merge(arr, start, mid, end);
        }

        void Merge(int[] arr, int start, int mid, int end)
        {
            int n1 = mid - start + 1;
            int n2 = end - (mid + 1);

            int[] l = new int[n1];
            int[] r = new int[n2];

            Copy(arr, start, mid, l);
            Copy(arr, mid + 1, end, r);

            int i = 0, j = 0, k = start;
            while (i < n1 && j < n2)
            {
                if (l[i] <= r[j])
                {
                    arr[k++] = l[i++];
                }
                else
                {
                    arr[k++] = r[j++];
                }
            }

            while (i < n1)
            {
                arr[k++] = l[i++];
            }

            while (j < n2)
            {
                arr[k++] = r[j++];
            }

        }

        void Copy(int[] original, int start, int end, int[] newArr)
        { }

    }
}
