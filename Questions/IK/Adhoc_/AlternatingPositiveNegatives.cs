 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Adhoc_
{
    class AlternatingPositiveNegatives
    {
        public static int[] alternating_positives_and_negatives(int[] array)
        {
            int[] result = new int[array.Length];

            int nexgPos = FindNextPositive(array, -1);
            int nextNeg = FindNextNegative(array, -1);
            
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == 0 && nexgPos != -1)
                {
                    result[i] = array[nexgPos];
                    nexgPos = FindNextPositive(array, nexgPos);
                }
                else if (i % 2 == 1 && nextNeg != -1)
                {
                    result[i] = array[nextNeg];
                    nextNeg = FindNextNegative(array, nextNeg);
                }
                else if (nexgPos != -1)
                {
                    result[i] = array[nexgPos];
                    nexgPos = FindNextPositive(array, nexgPos);
                }
                else if (nextNeg != -1)
                {
                    result[i] = array[nextNeg];
                    nextNeg = FindNextNegative(array, nextNeg);
                }
            }

            return result;
        }

        private static int FindNextPositive(int[] arr, int curIndex)
        {
            int newIndex = -1;

            for (int i = curIndex + 1; i < arr.Length; i++)
            {
                if (arr[i] >=0)
                {
                    newIndex = i;
                    break;
                }
            }

            return newIndex;
        }

        private static int FindNextNegative(int[] arr, int curIndex)
        {
            int newIndex = -1;

            for (int i = curIndex + 1; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    newIndex = i;
                    break;
                }
            }

            return newIndex;
        }
    }
}
  
