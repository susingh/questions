using Questions.IK.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Adhoc_
{
    class Sum_Zero
    {
        public static int[] sumZero(int[] arr)
        {
            //return sumZeroBF(arr);
            return sumZeroHashing(arr);
        }

        private static int[] sumZeroBF(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                long? localSum = null;
                for (int j = i; j < arr.Length; j++)
                {
                    if (!localSum.HasValue)
                    {
                        localSum = arr[j];
                    }
                    else
                    {
                        localSum += arr[j];
                    }

                    if (localSum == 0)
                    {
                        return new int[] { i, j };
                    }
                }
            }

            return new int[] { -1 };
        }

        public static int[] sumZeroHashing(int[] arr)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    return new int[] { i, i };
                }

                sum += arr[i];

                if (sum == 0)
                {
                    return new int[] { 0, i }; 
                }

                if (map.ContainsKey(sum))
                {
                    var lastIndex = map[sum];
                    if (lastIndex != map.Count - 1)
                    {
                        return new[] { lastIndex + 1, i };
                    }
                }

                map[sum] = i;
            }

            return new int[] { -1 };
        }
        
    }
}
