using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.String
{
    /// <summary>
    /// Given a string of length N and a charset of size m, find the shortest substring which has all the characters in the set in it.
    /// </summary>
    public class ShortestSubstringContainingSet
    {
        private class Result
        {
            public int LeftIndex;
            public int RightIndex;

            public Result()
            {
                LeftIndex = 0;
                RightIndex = int.MaxValue;
            }
        }

        public static string FindSubstring(string input, char[] set)
        {
            //var result = BruteForce(input, set);
            return SlidingWindow(input, set);

            //if (result.LeftIndex == 0 && result.RightIndex == int.MaxValue)
            //{
            //    return string.Empty;
            //}

            //return input.Substring(result.LeftIndex, result.RightIndex - result.LeftIndex + 1);

        }

        private static string SlidingWindow(string strText, char[] set)
        {
            // using the sliding window approach
            IDictionary<char, int> counts = new Dictionary<char, int>();
            foreach (char c in set)
            {
                counts[c] = 0;
            }

            string minString = strText;
            int missing = set.Length;
            
            // window
            int s = 0;
            int e = -1;

            while (e < strText.Length)
            {
                if (missing > 0)
                {
                    // expand
                    e++;

                    if (e == strText.Length)
                        break;

                    char ch = strText[e];

                    if (counts.ContainsKey(ch))
                    {
                        counts[ch] += 1;
                        if (counts[ch] == 1)
                            missing--;

                    }

                    if (missing == 0)
                    {
                        // check Length
                        int len = e - s + 1;
                        if (minString.Length > len)
                        {
                            minString = strText.Substring(s, len);
                        }
                    }
                }
                else if (missing == 0)
                {
                    // shrink
                    char ch = strText[s];
                    s++;

                    if (counts.ContainsKey(ch))
                    {
                        counts[ch] -= 1;
                        if (counts[ch] == 0)
                        {
                            missing++;
                        }
                    }

                    if (missing == 0)
                    {
                        // check Length
                        int len = e - s + 1;
                        if (minString.Length > len)
                        {
                            minString = strText.Substring(s, len);
                        }
                    }
                }
            }

                return minString;
        }

        private static Result BruteForce(string input, char[] set)
        {
            Result result = new Result();

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i; j < input.Length; j++)
                {
                    if (IsMatch(input, i, j, set))
                    {
                        int length = j - i + 1;
                        if (length < (result.RightIndex - result.LeftIndex))
                        {
                            result.LeftIndex = i;
                            result.RightIndex = j;
                        }
                    }
                }
            }

            return result;
        }

        private static bool IsMatch(string input, int start, int end, char[] set)
        {
            HashSet<char> map = new HashSet<char>();
            foreach (var item in set)
            {
                map.Add(item);
            }

            for (int i = start; i <= end; i++)
            {
                if (map.Contains(input[i]))
                {
                    map.Remove(input[i]);
                }

                if (map.Count == 0) return true;
            }

            return false;
        }
    }
}