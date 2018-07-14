using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
