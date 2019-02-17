using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Recursion
{
    class PalindromicDecomposition
    {
        public static string[] generate_palindromic_decompositions(string s)
        {
            List<string> results = new List<string>();
            generate_palindromic_decompositions(s, 0, results, string.Empty);
            return results.ToArray();
        }

        private static void generate_palindromic_decompositions(string s,
            int start,
            List<string> results,
            string output)
        {
            if (start == s.Length)
            {
                // remove the last "|" character;
                results.Add(output.Remove(output.Length - 1));
                return;
            }

            for (int i = start; i < s.Length; i++)
            {
                if (IsPalindrome(s, start, i))
                {
                    string newOutput = string.Format("{0}{1}|", output, s.Substring(start, i - start + 1));
                    generate_palindromic_decompositions(s, i + 1, results, newOutput);
                }
            }
        }

        private static bool IsPalindrome(string s, int i, int j)
        {
            while(i < j)
            {
                if (s[i++] != s[j--]) return false;
            }

            return true;
        }
    }
}
