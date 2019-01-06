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
            var result = BruteForce(input, set);

            if (result.LeftIndex == 0 && result.RightIndex == int.MaxValue)
            {
                return string.Empty;
            }

            return input.Substring(result.LeftIndex, result.RightIndex - result.LeftIndex + 1);
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