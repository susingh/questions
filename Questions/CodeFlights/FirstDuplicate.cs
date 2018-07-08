using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.CodeFlights
{
    class FirstDuplicate
    {
        int firstDuplicate(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                int val = Math.Abs(a[i]);

                if (a[val - 1] < 0)
                {
                    return val;
                }

                a[val - 1] = -a[val - 1];
            }
            return -1;
        }


        //private int firstDuplicate(int[] a)
        //{
        //    IDictionary<int, List<int>> duplicateIndex = new Dictionary<int, List<int>>();

        //    for (int i = 0; i < a.Length; i++)
        //    {
        //        int arrVal = a[i];
        //        if (!duplicateIndex.ContainsKey(arrVal))
        //        {
        //            duplicateIndex[arrVal] = new List<int>();
        //        }

        //        duplicateIndex[arrVal].Add(i);
        //    }

        //    int returnValue = -1;
        //    int minimumIndex = int.MaxValue;

        //    foreach (var item in duplicateIndex)
        //    {
        //        if (item.Value.Count > 1)
        //        {
        //            int secondIndex = item.Value.ElementAt(1);
        //            if (minimumIndex > secondIndex)
        //            {
        //                minimumIndex = secondIndex;
        //                returnValue = item.Key;
        //            }
        //        }
        //    }

        //    return returnValue;    
        //}

        public void Run()
        {
            var result = firstDuplicate(new int[] { 1, 2, 3, 2, 1 });
        }
    }
}
