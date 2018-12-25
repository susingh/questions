using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.String
{
    class SubstringSearch
    {
        public static int FindMatch(string word, string pattern)
        {
            //return FindBFMatch(word, pattern);
            return FindKMP(word, pattern);
        }

        /// <summary>
        /// O(NM)
        /// </summary>
        private static int FindBFMatch(string word, string pattern)
        {
            int i = 0;
            while (i < word.Length)
            {
                int startIndex = i;
                int j = 0;
                while (j < pattern.Length)
                {
                    if (word[i] == pattern[j])
                    {
                        i++;
                        j++;
                    }
                    else
                    {
                        i = startIndex + 1;
                        break;
                    }
                }

                if (j == pattern.Length)
                {
                    return startIndex;
                }
            }

            return -1;
        }

        /// <summary>
        /// O(N + M)
        /// </summary>
        private static int FindKMP(string word, string pattern)
        {
            int[] map = BuildTable(pattern);

            int i = 0;
            int startIndex = i;
            while (i < word.Length)
            {
                int j = 0;
                while (j < pattern.Length)
                {
                    if (word[i] == pattern[j])
                    {
                        j++;
                        i++;
                    }
                    else
                    {
                        if (j == 0)
                        {
                            i++;
                        }
                        else
                        {
                            // find the value at the previous index
                            j = map[j - 1];
                        }

                        startIndex = i - j;
                    }
                }

                if (j == pattern.Length)
                {
                    return startIndex;
                }
            }

            return -1;
        }

        private static int[] BuildTable(string pattern)
        {
            int j = 0;
            int i = j + 1;
            int[] map = new int[pattern.Length];
            map[0] = 0;

            while (i < pattern.Length)
            {
                if (pattern[i] == pattern[j])
                {
                    map[i] = j + 1;
                    j++;
                    i++;
                }
                else
                {
                    if (j != 0)
                    {
                        // Move back j to find a possible match
                        j = map[j - 1];
                    }
                    else
                    {
                        map[i] = 0;
                        i++;
                    }
                }
            }

            return map;
            // ABCDABD
            //return new int[] { 0, 0, 0, 0, 1, 2, 0 };
        }
    }
}