using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK
{
    /*
        quick sort - use when space is constaint
        merge sort - better on disk, locality of reference, takes extra space
     */ 
    class Sorting : IQuestion
    {
        void QuickSort(int[] arr)
        {

        }

        void QuickSort(int[] arr, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pivot = ChoosePivot(arr, start, end);
            int pi = Partition(arr, start, end, pivot);

            QuickSort(arr, start, pi - 1);
            QuickSort(arr, pi + 1, end);
        }

        private int Partition(int[] arr, int start, int end, int pivot)
        {
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

        private int ChoosePivot(int[] arr, int start, int end)
        {
            return start;
        }

        static string dutch_flag_sort(string balls)
        {
            char[] arr = balls.ToArray();

            int redIndex = 0;
            int blueIndex = arr.Length - 1;
            int i = 0;

                
            {
                if (arr[i] == 'R' && arr[redIndex] != 'R')
                {
                    swap(arr, i, redIndex);
                    redIndex++;
                }
                else if (arr[i] == 'B' && arr[blueIndex] != 'B')
                {
                    swap(arr, i, blueIndex);
                    blueIndex--;
                }
                else
                {
                    i++;
                }
            }

            return new string(arr);
        }

        static void swap<T>(T[] arr, int a, int b)
        {
            T temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        static int[] merger_first_into_second(int[] arr1, int[] arr2)
        {
            int readIndex1 = arr1.Length - 1;
            int readIndex2 = readIndex1;
            int writeIndex = arr2.Length - 1;

            while (readIndex1 >= 0 && readIndex2 >= 0)
            {
                if (arr2[readIndex2] > arr1[readIndex1])
                {
                    arr2[writeIndex] = arr2[readIndex2];
                    readIndex2--;
                }
                else
                {
                    arr2[writeIndex] = arr1[readIndex1];
                    readIndex1--;
                }

                writeIndex--;
            }

            while (readIndex1 >= 0 && writeIndex >=0)
            {
                arr2[writeIndex] = arr1[readIndex1];
                writeIndex--;
            }

            while(readIndex2 >= 0 && writeIndex >= 0)
            {
                arr2[writeIndex] = arr2[readIndex2];
                writeIndex--;
            }
            
            return arr2;
        }

        public void Run()
        {
            //var result = dutch_flag_sort("GR");

            int[] arr1 = { 2, 4, 5 };
            int[] arr2 = { 2, 4, 5, 0, 0, 0 };

            var result = merger_first_into_second(arr1, arr2);
        }

        void MergeSort(int[] arr)
        {
            if (arr == null)
            {
                return;
            }

            MergeSort(arr, 0, arr.Length - 1);
        }

        void MergeSort (int[] arr, int start, int end)
        {
            if (start >= end) return;
            
            int mid = start + (end - start) / 2;
            MergeSort(arr, start, mid);
            MergeSort(arr, mid + 1, end);
            Merge(arr, start, mid, end);
        }

        void Merge(int[] arr, int start, int mid, int end)
        {
            int n1 = mid - start + 1;
            int n2 = end - (mid + 1);

            int[] l = new int[n1];
            int[] r = new int[n2];

            Copy(arr, start, mid, l);
            Copy(arr, mid+1, end, r);

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
