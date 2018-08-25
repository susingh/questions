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
    }
}
