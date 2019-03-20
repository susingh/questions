using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.String
{
    class LongestPalindromeSubstring
    {
        public static string FindSubString(string text)
        {
            string longestString = string.Empty;

            // for each index, expand both left and right and check if string is palindrome

            for (int i = 0; i < text.Length; i++)
            {
                // i is the starting position

                // odd case
                int l = i;
                int r = i;

                while (l >= 0 && r < text.Length && text[l] == text[r])
                {
                    int len = r - l + 1;
                    if (longestString.Length < len)
                    {
                        longestString = text.Substring(l, len);
                    }

                    l--;
                    r++;
                }

                // even case
                l = i;
                r = i+1;

                while (l >= 0 && r < text.Length && text[l] == text[r])
                {
                    int len = r - l + 1;
                    if (longestString.Length < len)
                    {
                        longestString = text.Substring(l, len);
                    }

                    l--;
                    r++;
                }
            }

            return longestString;
        }
    }
}
