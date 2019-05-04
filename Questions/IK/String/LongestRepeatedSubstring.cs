using Questions.Models;
using System;
using System.Collections.Generic;

namespace Questions.IK.String
{
    class LongestRepeatedSubstring
    {
        public static string LRS(string iString)
        {
            //return LRS_BruteForce(iString);
            return LRS_SuffixTrees(iString);
        }

        private static string LRS_SuffixTrees(string iString)
        {
            TrieNode root = BuildTree(iString);
            Stack<char> path = new Stack<char>();
            List<char> longest = new List<char>();

            foreach (var child in root.Children)
            {
                path.Push(child.Key);
                dfs(child.Value, path, ref longest);
                path.Pop();
            }

            return new string(longest.ToArray());
        }

        private static void dfs(TrieNode root, Stack<char> path, ref List<char> longest)
        {
            if(root.Children.Count == 1 && root.Children.ContainsKey('$'))
            {
                return;
            }

            if (root.Children.Count >= 2)
            {
                if (longest.Count == 0 || path.Count > longest.Count)
                {
                    longest = new List<char>(GetString(path));
                }
            }

            foreach(var child in root.Children)
            {
                path.Push(child.Key);
                dfs(child.Value, path, ref longest);
                path.Pop();
            }
        }

        private static char[] GetString(Stack<char> path)
        {
            var arr = path.ToArray();
            Array.Reverse(arr);
            return arr;
        }

        private static TrieNode BuildTree(string iString)
        {
            TrieNode root = new TrieNode();
            for (int i = iString.Length - 1; i >= 0; i--)
            {
                InsertIntoTrie(iString, i, root);
            }
            return root;
        }

        private static void InsertIntoTrie(string iString, int start, TrieNode root)
        {
            TrieNode curr = root;
            for (int i = start; i < iString.Length; i++)
            {
                char ch = iString[i];
                if (!curr.Children.ContainsKey(ch))
                {
                    curr.Children.Add(ch, new TrieNode());
                }

                curr = curr.Children[ch];
            }

            curr.Children['$'] = new TrieNode();
        }

        private static string LRS_BruteForce(string iString)
        {
            char[] arr = iString.ToCharArray();

            string longestSubstring = string.Empty;
            int longLength = 0;

            Dictionary<string, int> set = new Dictionary<string, int>();

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    string substring = GetString(arr, i, j);
                    int length = substring.Length;

                    if (set.ContainsKey(substring))
                    {
                        if (length > longLength)
                        {
                            longLength = length;
                            longestSubstring = substring;
                        }

                        set[substring] = set[substring] + 1;
                    }
                    else
                    {
                        set[substring] = 1;
                    }
                }
            }

            return longestSubstring;
        }

        private static string GetString(char[] arr, int start, int end)
        {
            return new string(arr, start, end - start + 1);
        }
    }
}
