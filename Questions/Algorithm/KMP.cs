using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.Algorithm
{
    /// <summary>
    /// Knuth-Morris-Prat
    /// </summary>
    public class KMP
    {
        public int[] FindMatches(string word, string pattern)
        {
            List<int> matches = new List<int>();
            int[] map = BuildTable(pattern);
            int i = 0;
            
            while (i < word.Length)
            {
                int startIndex = i;
                int j = 0;
                while (j < pattern.Length && i < word.Length)
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
                    matches.Add(startIndex);
                    i = startIndex + 1;
                }
            }

            if (matches.Count == 0)
            {
                matches.Add(-1);
            }

            return matches.ToArray();
        }

        private int[] BuildTable(string pattern)
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
        }
    }
}
