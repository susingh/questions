using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.String
{
    class LongestSubstringWith2DistinctChars
    {
        public static int getLongestSubstringLengthExactly2DistinctChars(string input)
        {
            int maxLength = 0;

            // expand the window to the right if count == 2
            // stop expand when count == 3; shrink until count == 2 again
            // repeat

            int s = 0;
            int e = -1;
            int distinct = 0;

            Dictionary<char, int> map = new Dictionary<char, int>();

            foreach (char ch in input)
            {
                map[ch] = 0;
            }

            while (e < input.Length - 1)
            {
                if (distinct <= 2)
                {
                    e++;

                    char ch = input[e];
                    map[ch] += 1;

                    if (map[ch] == 1)
                    {
                        distinct++;
                    }

                    if (distinct == 2)
                    {
                        int len = e - s + 1;
                        maxLength = Math.Max(maxLength, len);
                    }
                }
                else if (distinct == 3)
                {
                    char ch = input[s];
                    map[ch] -= 1;

                    if (map[ch] == 0)
                    {
                        distinct--;
                    }

                    s++;

                    if (distinct == 2)
                    {
                        int len = e - s + 1;
                        maxLength = Math.Max(maxLength, len);
                    }
                }
            }

            return maxLength;
        }

    }
}