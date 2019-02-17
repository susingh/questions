using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Recursion
{
    class Permutations
    {
        /*
         * Original permutation problem
         */
        void PermuteBasic(char[] arr)
        {
            PermuteBasic(arr, 0);
        }

        void PermuteBasic(char[] arr, int i)
        {
            if (i == arr.Length - 1)
            {
                Console.Write(arr);
                return;
            }

            for (int j = i; j < arr.Length; j++)
            {
                Utils.Swap(arr, i, j);
                PermuteBasic(arr, i + 1);
                Utils.Swap(arr, i, j);
            }
        }


        /*
         * Assume that the input is an array of size 'n' where 'n' is an even number. 
         * Additionally, assume that half the integers are even and the other half are odd. 
         * Print only those permutations where odd and even integers alternate, starting with odd.
         */

        void PermuteOddEven(int[] arr)
        {
            PermuteOddEven(arr, 0, false);
        }

        void PermuteOddEven(int[] arr, int i, bool isEven)
        {
            if (i == arr.Length - 1)
            {
                Print(arr);
                return;
            }

            for (int j = i; j < arr.Length; j++)
            {
                if (isEven && arr[j] % 2 != 0 ||
                    !isEven && arr[j] % 2 == 0)
                {
                    continue;
                }

                Utils.Swap(arr, i, j);
                PermuteOddEven(arr, i + 1, !isEven);
                Utils.Swap(arr, i, j);
            }
        }

        private void Print<T>(T[] arr)
        {
            throw new NotImplementedException();
        }

        /*
         * Assume that the input is an array of characters. 
         * Print any one permutation that is also a word in the dictionary. Assume that you have two library functions you can use.
         * 
         * bool ValidWord(char array a) returns true if and only if the string a is a dictionary word.
         * bool ValidWordPrefix(char array a, int a_size) returns true if and only if a[0...a_size-1] is a prefix of at least one word in the dictionary
         */

        void PermuteValidWord(char[] arr)
        {
            PermuteValidWord(arr, 0);
        }

        bool PermuteValidWord(char[] arr, int i)
        {
            bool found = false;

            if (i == arr.Length - 1)
            {
                if (ValidWord(arr))
                {
                    Print(arr);
                    found = true;
                }
            }
            else
            {
                for (int j = i; j < arr.Length; j++)
                {
                    Utils.Swap(arr, i, j);
                    if (ValidWordPrefix(arr, i + 1))
                    {
                        found = PermuteValidWord(arr, i + 1);
                        if (found)
                        {
                            break;
                        }
                    }
                    Utils.Swap(arr, i, j);
                }
            }

            return found;
        }

        bool ValidWord(char[] arr)
        {
            string a = new string(arr);
            return (a == "cat");
        }

        bool ValidWordPrefix(char[] arr, int a_size)
        {
            string a = new string(arr, 0, a_size);
            return (a == "c" || a == "ca");
        }
    }
}