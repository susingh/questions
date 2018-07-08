using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.LeetCode
{
    public class Reverse_String
    {
        public string ReverseString(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return s;
            }

            char[] arr = s.ToCharArray();

            for (int i = 0, j= arr.Length -1; i <= j; i++, j--)
            {
                char temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }

            return new string(arr);
            
        }

        public void Run()
        {
            Console.WriteLine(ReverseString("hello"));
        }
    }

}
