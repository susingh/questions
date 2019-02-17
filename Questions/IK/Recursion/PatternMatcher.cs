using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Recursion
{
    /// <summary>
    /// Pattern can be have letters, numbers, '.' and '*'
    /// </summary>
    class PatternMatcher
    {
        public bool IsMatch(string input, string pattern)
        {
            // preprocess the pattern and squish all the stars together
            return IsMatch(input, 0, pattern, 0);
        }

        private bool IsMatch(string s, int i, string p, int k)
        {
            // base case
            if (i == s.Length)
            {
                if (k == p.Length) return true;
                else
                {
                    while(k < p.Length)
                    {
                        if (p[k] != '*')
                        {
                            return false;
                        }
                    }

                    return true;
                }
            }

            if (k == p.Length && i < s.Length)
            {
                return false;
            }

            if (p[i] == '.')
            {
                return IsMatch(s, i + 1, p, k + 1);
            }
            else if (p[i] != '.' && p[i] != '*')
            {
                if (s[i] == p[k])
                {
                    return IsMatch(s, i + 1, p, k + 1);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                // none matched or one matced
                return IsMatch(s, i, p, k + 1) || IsMatch(s, i+1, p, k);
            }
        }
    }
}
