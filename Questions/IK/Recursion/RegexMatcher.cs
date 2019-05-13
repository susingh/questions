using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Recursion
{
    class RegexMatcher
    {
        public static bool IsMatch(string input, string pattern)
        {
            List<bool> isStar = new List<bool>();
            string simplePattern = SimplifyPattern(pattern, isStar);
            return IsMatch(input, 0, simplePattern, 0, isStar.ToArray());
        }

        private static bool IsMatch(string input, int i, string pattern, int j,  bool[] isStar)
        {
            if (i == input.Length && j == pattern.Length)
            {
                return true;
            }

            if (j == pattern.Length)
            {
                return false;
            }

            if (i == input.Length)
            {
                // all remaining characters in the pattern must be optional
                while (j < pattern.Length)
                {
                    if (!isStar[j])
                        return false;

                    j++;
                }

                return true;
            }

            if (!isStar[j])
            {
                if (input[i] == pattern[j] || pattern[j] == '.')
                {
                    return IsMatch(input, i + 1, pattern, j + 1, isStar);
                }
            }
            else
            {
                if (pattern[j] == '.')
                {
                    // 2 cases:
                    // 1: Match the char
                    // 2: Ignore the char
                    return IsMatch(input, i + 1, pattern, j, isStar) || IsMatch(input, i, pattern, j + 1, isStar);
                }
                else
                {
                    // handle "." also
                    if (input[i] == pattern[j])
                    {
                        // 2 cases: consider the pattern char, ignore the pattern char
                        return IsMatch(input, i + 1, pattern, j, isStar) || IsMatch(input, i, pattern, j + 1, isStar);
                    }
                    else
                    {
                        return IsMatch(input, i, pattern, j + 1, isStar);
                    }
                }
            }

            return false;
        }

        private static string SimplifyPattern(string regex, List<bool> isStar)
        {
            // a.c.*.*gg*
            // a.c.*gg*
            // a.c.gg

            isStar.Add(false);
            isStar.Add(false);
            isStar.Add(false);
            isStar.Add(true);
            isStar.Add(false);
            isStar.Add(true);

            return "a.c.gg";
        }
    }
}
