using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Sorting
{
    class MergeKSortedArrays
    {
        private class HeapItem
        {
            public int stream;
            public int index;
            public int value;
        }

        private class HeapItemCompare : IComparer<HeapItem>
        {
            private bool _isAsc;

            public HeapItemCompare(bool isAscending)
            {
                _isAsc = isAscending;
            }

            public int Compare(HeapItem x, HeapItem y)
            {
                if (x.value == y.value)
                {
                    if (x.stream == y.stream)
                    {
                        if (x.index == y.index)
                        {
                            return 0;
                        }
                        else
                        {
                            return x.index < y.index ? -1 : 1;
                        }
                    }
                    else
                    {
                        return x.stream < y.stream ? -1 : 1;
                    }
                }
                else if (x.value < y.value)
                {
                    return _isAsc ? -1 : 1;
                }
                else
                {
                    return _isAsc ? 1 : -1;
                }
            }
        }

        public static int[] mergeArrays(int[][] arr)
        {
            int k = arr.Length;
            int N = arr[0].Length;

            int[] result = new int[k * N];

            bool isAsc = false;
            for (int i = 0; i < k; i++)
            {
                if (arr[i][0] == arr[i][N - 1])
                {
                    continue;
                }

                isAsc = arr[i][0] < arr[i][N - 1];
                break;
            }

            SortedSet<HeapItem> heap = new SortedSet<HeapItem>(new HeapItemCompare(isAsc));

            for (int i = 0; i < k; i++)
            {
                heap.Add(new HeapItem() { value = arr[i][0], index = 0, stream = i });
            }

            for (int i = 0; i < result.Length; i++)
            {
                var item = heap.ElementAt(0);
                heap.Remove(item);

                int newIndex = ++item.index;
                if (newIndex < N)
                {
                    heap.Add(new HeapItem() { value = arr[item.stream][newIndex], index = newIndex, stream = item.stream });
                }
                else
                {

                }

                result[i] = item.value;
            }

            return result;
        }
    }
}
