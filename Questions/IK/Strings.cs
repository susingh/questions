using Questions.IK.String;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Questions.IK
{
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

        public void Run()
        {
            // var result
                //= SubstringSearch("SUMIT", "TIM");
                // = LRS("abcpqrabpqpq");

        }

    }
}
