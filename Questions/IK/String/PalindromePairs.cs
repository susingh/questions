using Questions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.String
{
    /// <summary>
    /// Given a collection of words find if combining any two words make palindrome
    /// </summary>
    class PalindromePairs
    {
        public static List<string> FindPairs(string[] words)
        {
            TrieNode trie = BuildTrie(words);     // NM

            string[] reverseWords = ReverseWords(words); // NM
            TrieNode reversetrie = BuildTrie(reverseWords);   // NM

            List<string> pairs = new List<string>();

            FindPairs(trie, reverseWords, pairs); // NM
            FindPairs(reversetrie, words, pairs); // NM

            return pairs;
        }

        private static string[] ReverseWords(string[] words)
        {
            var list = new List<string>();
            foreach (var item in words)
            {
                list.Add(new string(item.Reverse().ToArray()));
            }
            return list.ToArray();
        }

        private static TrieNode BuildTrie(string[] words)
        {
            TrieNode root = new TrieNode();
            foreach (var word in words)
            {
                InsertTrie(root, word);
            }
            return root;
        }

        private static void InsertTrie(TrieNode root, string word)
        {
            TrieNode curr = root;
            int i = 0;

            while (i < word.Length)
            {
                if (!curr.Children.ContainsKey(word[i]))
                    curr.Children[word[i]] = new TrieNode();

                curr = curr.Children[word[i]];
                i++;
            }

            curr.isEOW = true;
        }

        private static void FindPairs(TrieNode root, string[] words, List<string> result)
        {
            foreach (var word in words)
            {
                int index = FindMatch(root, word);

                if (index == -1)
                {
                    continue;
                }
                else
                {
                    int i = index + 1;
                    int j = word.Length - 1;

                    while (i < j)
                    {
                        if (word[i] != word[j])
                            return;
                    }


                }
            }
        }

        private static int FindMatch(TrieNode trie, string word)
        {
            TrieNode curr = trie;

            int i = 0;
            while (i < word.Length)
            {
                if (!curr.Children.ContainsKey(word[i]))
                    i--;

                curr = curr.Children[word[i]];
                i++;
            }

            return curr.isEOW ? i : -1;
        }
    }
}