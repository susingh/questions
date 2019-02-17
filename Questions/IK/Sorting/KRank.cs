using Questions.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Sorting
{
	/// <summary>
    /// Given an array in integers, find the element at rank k
    /// </summary>
    class KRank
    { 
		public static int FindRankK(int[] arr, int k)
        {
            return FindRankKSorting(arr, k);
        }

		private static int FindRankKSorting(int[] arr, int k)
        {
            Array.Sort(arr);
            return arr[k-1];
        }

		private static int FindRankKMinHeap(int[] arr, int k)
        {
            MinHeap<int> heap = new MinHeap<int>();
            foreach (var item in arr)
            {
                heap.Add(item);
            }

            for (int i = 0; i < k-1; i++)
            {
                heap.Delete();
            }

            return heap.Peek();
        }

		private static int FindRankKQuickSelect(int[] arr, int k)
        {
            return FindRankKQuickSelect(arr, 0, arr.Length - 1, k);
        }

		private static int FindRankKQuickSelect(int[] arr, int start, int end, int k)
        {
            int pI = Paritition(arr, start, end);
            if (pI + 1 == k)
            {
                return arr[pI];
            }
            else if (pI + 1 < k)
            {
                return FindRankKQuickSelect(arr, pI + 1, end, k);
            }
            else
            {
                return FindRankKQuickSelect(arr, start, pI - 1, k);
            }
        }

        private static int Paritition(int[] arr, int start, int end)
        {
            return -1;
        }
    }
}
