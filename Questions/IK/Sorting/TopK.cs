using Questions.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Questions.IK.Sorting
{
    public class TopK
    {
        /*
		 * 1. Brute force - sort the array and pick the top items from the end
		 * 2. Use a heap or priority queue	
		 */
        public static int[] solve(int[] arr, int k)
        {
            SortedList<int, int> list = new SortedList<int, int>(new DescendingOrder());
            list.Add(arr[0], arr[0]);

            for (int i = 1; i < arr.Length; i++)
            {
                if (list.ContainsKey(arr[i]))
                    continue;

                list.Add(arr[i], arr[i]);

                if (list.Count > k)
                {
                    list.RemoveAt(list.Count - 1);
                }
            }

            return list.Keys.ToArray();
        }

        private class Stream
        {
            public int Next()
            {
                return new Random((int)DateTime.UtcNow.Ticks).Next(-1, 1000);
            }
        }

        private static void PrintTopK(Stream ip, int k, int magicNumber)
        {
            MinHeap<int> heap = new MinHeap<int>();
            int val;
            while ((val = ip.Next()) != -1)
            {
                if (val == magicNumber)
                {
                    // print the heap
                    continue;
                }

                if (heap.Count == k)
                {
                    if (heap.Peek() < val)
                    {
                        heap.Delete();
                        heap.Add(val);
                    }
                }
                else
                {
                    heap.Add(val);
                }
            }
        }
        
    }
}
