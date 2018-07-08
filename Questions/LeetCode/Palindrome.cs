using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.LeetCode
{
    public class Palindrome
    {
        public bool IsPalindrome(string s)
        {
            if (s == string.Empty)
            {
                return true;
            }

            s = s.ToLower();

            StringBuilder builder = new StringBuilder();

            foreach (char item in s)
            {
                if (Char.IsLetterOrDigit(item))
                {
                    builder.Append(item);
                }
            }

            string newS = builder.ToString();

            for (int i = 0, j = newS.Length - 1; i <= j; i++, j--)
            {
                if (newS[i] != newS[j])
                {
                    return false;
                }
            }

            return true;
        }

        public void Run()
        {
            Console.WriteLine(IsPalindrome("A man, a plan, a canal: Panama"));
            Console.WriteLine(IsPalindrome("race a car"));
        }
    }
}
