using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.GFG.String
{
    /// <summary>
    /// https://www.geeksforgeeks.org/reverse-an-array-without-affecting-special-characters/
    /// </summary>
    class ReverseSpecialString
    {
        public static string Reverse(string str)
        {
            //return ReverseBF(str);
            return ReverseEfficient(str);
        }

        private static string ReverseBF(string str)
        {
            char[] arr = str.ToCharArray();
            char[] result = new char[arr.Length];

            int rptr = arr.Length - 1;
            int wptr = 0;

            while (wptr < arr.Length && rptr >= 0)
            {
                while (!char.IsLetter(arr[wptr]) && wptr < arr.Length)
                {
                    result[wptr] = arr[wptr];
                    wptr++;
                }

                while (!char.IsLetter(arr[rptr]) && rptr >= 0)
                    rptr--;

                result[wptr++] = arr[rptr--];
            }

            return new string(result);
        }

        private static void Swap(char[] arr, int a, int b)
        {
            char temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        private static string ReverseEfficient(string str)
        {
            char[] arr = str.ToCharArray();

            int r = arr.Length - 1;
            int l = 0;

            while (l < r)
            {
                while (!char.IsLetter(arr[l]) && l < arr.Length)
                    l++;

                while (!char.IsLetter(arr[r]) && r >= 0)
                    r--;

                if (l < r)
                {
                    Swap(arr, l, r);
                    l++;
                    r--;
                }
            }

            return new string(arr);
        }
    }
}
