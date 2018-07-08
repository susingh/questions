using System;
using System.Collections.Generic;
using System.Linq;

namespace Questions.IK
{

    class TrieNode
    {
        public Dictionary<char, TrieNode> Children;
        public bool isEow;

        public TrieNode()
        {
            Children = new Dictionary<char, TrieNode>();
        }
    }

    class Strings : IQuestion
    {
        bool SubstringSearch(string s, string p)
        {
            bool found = false;
            int i = 0;
            while (i < s.Length)
            {
                int j = 0;
                int k = i;
                while (j < p.Length && k < s.Length)
                {
                    if (s[k] != p[j]) break;
                    k++;
                    j++;
                }

                if (j == p.Length)
                {
                    found = true;
                    break;
                }

                i++;
            }

            return found;
        }

        void PrintPalindromePairs(List<string> words)
        {
            HashSet<string> results = new HashSet<string>();
            FindPalindromePairs(words, results);
            Print(results);
        }

        void Print(HashSet<string> words)
        {
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }

        List<string> ReverseWords(List<string> words)
        {
            return words;
        }

        void FindPalindromePairs(List<string> words, HashSet<string> results)
        {
            List<string> reverseWords = ReverseWords(words);
            TrieNode root = BuildTrie(words);
            TrieNode reverseRoot = BuildTrie(words);

            FindWord(root, reverseWords, results);
            FindWord(reverseRoot, words, results);
        }

        void FindWord(TrieNode root, List<string> words, HashSet<string> results)
        {
            foreach (var word in words)
            {
                FindWord(root, word, results);
            }
        }

        void FindWord(TrieNode root, string word, HashSet<string> result)
        {

        }

        TrieNode BuildTrie(List<string> words)
        {
            TrieNode root = new TrieNode();

            foreach (var word in words)
            {
                InsertIntoTrie(word, root);
            }

            return root;
        }

        void InsertIntoTrie(string word, TrieNode root)
        {
            TrieNode curr = root;
            foreach (char c in word)
            {
                if (!curr.Children.ContainsKey(c))
                {
                    TrieNode node = new TrieNode();
                    curr.Children[c] = node;
                }

                curr = curr.Children[c];
            }

            curr.isEow = true;
        }

        static string LRS(string iString)
        {
            //return LRSBF(iString);
            return LRS_SuffixTrees(iString);
        }

        static string LRSBF(string iString)
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
                    int length = j - i + 1;

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
        static string GetString(char[] arr, int start, int end)
        {
            return new string(arr, start, end - start + 1);
        }

        static string LRS_SuffixTrees(string word)
        {
            TrieNode root = BuildTree(word);


            char[] arr = new char[word.Length + 1];
            List<string> suffixes = new List<string>();

            foreach (var child in root.Children)
            {
                arr[0] = child.Key;
                dfs(child.Value, arr, 1, suffixes);
            }

            int lrs_length = 0;
            string lrs = string.Empty;
            foreach (var item in suffixes)
            {
                if (item.Length > lrs_length)
                {
                    lrs = item;
                    lrs_length = item.Length;
                }
            }

            return lrs;
        }

        private static void dfs(TrieNode node, char[] arr, int i, List<string> suffixes)
        {
            TrieNode curr = node;
            if (curr.Children.Count == 0)
            {
                return;
            }

            if (curr.Children.Count >= 2)
            {
                suffixes.Add(new string(arr, 0, i));
            }

            foreach(var child in curr.Children)
            {
                arr[i] = child.Key;
                dfs(child.Value, arr, i + 1, suffixes);
            }
        }

        static void InsertIntoTrie(string word, int start, TrieNode root)
        {
            TrieNode curr = root;
            for (int i = start; i < word.Length; i++)
            {
                if (!curr.Children.ContainsKey(word[i]))
                {
                    TrieNode node = new TrieNode();
                    curr.Children[word[i]] = node;
                }

                curr = curr.Children[word[i]];
            }

            curr.Children['$'] = new TrieNode();
            //curr.isEow = true;
        }

        private static TrieNode BuildTree(string word)
        {
            TrieNode root = new TrieNode();
            for (int i = word.Length -1; i >= 0; i--)
            {
                InsertIntoTrie(word, i, root);
            }

            return root;
        }
        
        public void Run()
        {
            var result
                //= SubstringSearch("SUMIT", "TIM");
                = LRS("abcpqrabpqpq");

        }

    }
}
