using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Sorting
{
    class MergeTwoArrays
    {
        public static int[] merger_first_into_second(int[] arr1, int[] arr2)
        {
            int readIndex1 = arr1.Length - 1;
            int readIndex2 = arr2.Length / 2 - 1;

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

            while (readIndex1 >= 0 && writeIndex >= 0)
            {
                arr2[writeIndex] = arr1[readIndex1];
                readIndex1--;
                writeIndex--;
            }

            while (readIndex2 >= 0 && writeIndex >= 0)
            {
                arr2[writeIndex] = arr2[readIndex2];
                readIndex2--;
                writeIndex--;
            }

            return arr2;
        }
    }
}
