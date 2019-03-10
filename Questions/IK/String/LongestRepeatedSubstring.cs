using Questions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.String
{
    class RepeatedResult
    {
        public int Count;
        public string LongestString;
    }

    public class LongestRepeatedSubstring
    {
        public static string FindString(string input)
        {
            // O(N^2)
            TrieNode root = BuildTrie(input);

            // O(N^2)
            Stack<char> path = new Stack<char>();
            RepeatedResult result = new RepeatedResult();
            foreach (var item in root.Children)
            {
                path.Push(item.Key);
                FindStringDfs(item.Value, path);
                path.Pop();
            }
            
            return result.LongestString;
        }

        private static string GetPath(Stack<char> path)
        {
            var arr = path.ToArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        private static RepeatedResult FindStringDfs(TrieNode root, Stack<char> path)
        {
            // base case
            if (root.Children.Count == 0 && root.isEOW)
            {
                return new RepeatedResult { Count = 1, LongestString = GetPath(path) };
            }
           
            // local decision


            string longestChildStr = string.Empty;
            int totalCount = 0;

            foreach (var child in root.Children)
            {
                path.Push(child.Key);

                var childResult = FindStringDfs(child.Value, path);
                totalCount += childResult.Count;

                if (longestChildStr.Length < childResult.LongestString.Length)
                {
                    longestChildStr = childResult.LongestString;
                }

                path.Pop();
            }

            var result = new RepeatedResult()
            {
                Count = totalCount
            };

            if (result.Count > 1)
            {
                result.LongestString = GetPath(path);
            }
            else
            {
                result.LongestString = longestChildStr;
            };

            return result;
        }

        private static TrieNode BuildTrie(string input)
        {
            throw new NotImplementedException();
        }
    }
}
