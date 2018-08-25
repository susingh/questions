using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK
{
  
    class Adhoc : IQuestion
    {
        /// <summary>
        /// T: O(n) S: O(n)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sum"></param>
        void TwoSumLinear(int[] arr, int start, int sum)
        {
            HashSet<int> set = new HashSet<int>();

            for (int i = start; i < arr.Length; i++)
            {
                if (set.Contains(sum - arr[i]))
                {
                    Console.WriteLine($"{arr[i]},{sum - arr[i]}");
                }

                set.Add(arr[i]);
            }
        }


        /// <summary>
        ///  T: O(nlogn) S: O(1)
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="sum"></param>
        void TwoSumSorted(int[] arr, int sum)
        {
            Array.Sort(arr);
            int i = 0, j = arr.Length - 1;
            while (i < j)
            {
                int temp = arr[i] + arr[j];
                if (temp == sum)
                {
                    Console.WriteLine($"{arr[i]},{arr[j]}");
                    i++;
                    j--;
                }
                else if (temp < sum)
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }
        }

        void Find2Sum(int[] arr, int k)
        {
            TwoSumLinear(arr, 0, k);
            TwoSumSorted(arr, k);
        }

        void Find3SumHashing(int[] arr, int k)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]},");
                TwoSumLinear(arr, i + 1, k - arr[i]);
            }
        }

        void Find3Sum(int[] arr, int k)
        {
            Find3SumHashing(arr, k);
        }

        class CustomComparer : IComparer<int[]>
        {
            public int Compare(int[] x, int[] y)
            {
                if (x[0] == y[0])
                {
                    return 0;
                }
                else if (x[0] < y[0])
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
        }

        static int[][] getMergedIntervals(int[][] inputArray)
        {
            Array.Sort(inputArray, new CustomComparer());

            List<int[]> output = new List<int[]>();
            output.Add(inputArray[0]);

            for (int i = 1; i < inputArray.Length; i++)
            {
                var previous = output[output.Count - 1];
                var curr = inputArray[i];

                if (curr[0] >= previous[0] && curr[0] <= previous[1])
                {
                    if (curr[1] > previous[1])
                    {
                        previous[1] = curr[1];
                    }
                }
                else
                {
                    output.Add(curr);
                }
            }

            return output.ToArray();
        }

        static int[] sumZero(int[] arr)
        {
            for (int start = 0; start < arr.Length; start++)
            {
                int cumSum = 0;

                for (int end = start; end < arr.Length; end++)
                {
                    cumSum += arr[end];

                    if (cumSum == 0)
                    {
                        return new int[] { start, end };
                    }
                }
            }

            return new int[] { -1 };
        }

        static long divide(long a, long b)
        {
            bool isANegative = false;
            bool isBNegative = false;

            if (a < 0)
            {
                isANegative = true;
                a = ~a + 1;
                //a = a >>> 1;
            }
            
            if (b < 0)
            {
                isBNegative = true;
                b = ~b + 1;
            }


            long quotient = 0;
            long remaining = a;
            while (remaining >= b)
            {
                remaining = remaining - b;
                quotient++;
            }

            if (isBNegative == isANegative)
            {
                return quotient;
            }
            else
            {
                quotient = ~quotient + 1;
                return quotient;
            }
        }

        static string detect_primes(int[] a)
        {
            char[] result = new char[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                if (IsPrime(a[i]))
                {
                    result[i] = '1';
                }
                else
                {
                    result[i] = '0';
                }
            }

            return new string(result);
        }

        static bool IsPrime(int a)
        {
            if (a == 1) return false;
            if (a == 2) return true;
            if (a % 2 == 0) return false;

            int floor = (int)Math.Floor(Math.Sqrt(a));

            for (int i = 3; i < floor; i++)
            {
                if (a % i == 0) return false;
            }

            return true;
        }

        static string move_letters_to_left_side_with_minimizing_memory_writes(string s)
        {
            char[] arr = s.ToCharArray();
            int wPtr = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (!char.IsDigit(arr[i]))
                {
                    arr[wPtr] = arr[i];
                    wPtr++;
                }
            }

            return new string(arr);
        }

        static string reverse_ordering_of_words(string s)
        {
            char[] arr = s.ToCharArray();

            reverse(arr, 0, arr.Length - 1);

            int k = 0;
            while (k < arr.Length)
            {
                if (arr[k] == ' ')
                {
                    k++;
                    continue;
                }
                else
                {
                    int start = k;
                    while (k < arr.Length && arr[k] != ' ')
                    {
                        k++;
                    }

                    int end = k - 1;
                    reverse(arr, start, end);
                }
            }

            return new string(arr);
        }

        static void reverse(char[] arr, int start, int end)
        {
            int i = start;
            int j = end;
            while (i < j)
            {
                char temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;

                i++;
                j--;
            }
        }

       
        public void Run()
        {
            //var result = MaxSumSubArray(new int[] { -1, 3, 2, -4, 5, 2, -2 });
            //Find2Sum(new int[] { -1, 3, 2, 4, 6, -2 }, 5);
            //Find3Sum(new int[] { -1, 3, 2, 4, 6, -2 }, 5);
            int[][] input = new int[][]
            {
                new int[] { 10, 12},
                new int[] { 1, 2},
                new int[] { 1000, 100000},
                new int[] { -1000000000, 1000000000 },
                new int[] { 2, 5 },
                new int[] { 7, 10 },
                new int[] { 123, 456 }
            };

            //var result = getMergedIntervals(input);

            //var result = sumZero(new int[] { 6, 5, 1, 2, -3, 7, -4 });
            //var result = divide(-5, 2);

            //var result = detect_primes(new int[] { 6, 2, 5, 8 });

            //var result = move_letters_to_left_side_with_minimizing_memory_writes("0a193zbr");
            //var result = reverse_ordering_of_words("   word1  word2 ");

        }
    }

    //class KVStore
    //{
    //    Array<k,v> arr;
    //    HashSet<K, Index>
    //}
}
