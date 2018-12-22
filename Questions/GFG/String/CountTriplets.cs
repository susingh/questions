using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.GFG.String
{
    /// <summary>
    /// https://www.geeksforgeeks.org/count-triplets-with-sum-smaller-that-a-given-value/
    /// </summary>
    class CountTriplets
    {
        public static int Count(int[] arr, int k)
        {
            return CountBF(arr, k);
        }

        private static int CountBF(int[] arr, int sum)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i+1; j < arr.Length; j++)
                {
                    for (int k = j+1; k < arr.Length; k++)
                    {
                        int val = arr[i] + arr[j] + arr[k];

                        if (val < sum)
                        {
                            Console.WriteLine($"{arr[i]} {arr[j]} {arr[k]}");
                            count++;
                        }
                    }
                }
            }

            return count;
        }
    }
}
