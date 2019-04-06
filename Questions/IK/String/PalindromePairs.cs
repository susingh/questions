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
            TrieNode trie = new TrieNode();
            TrieNode reversetrie = new TrieNode();

            string[] reverseWords = ReverseWords(words); // NM

            BuildTrie(trie, words);     // NM
            BuildTrie(reversetrie, reverseWords);   // NM

            List<string> pairs = new List<string>();

            FindPairs(trie, reverseWords, pairs); // NM
            FindPairs(reversetrie, words, pairs); // NM

            return pairs;
        }

        private static string[] ReverseWords(string[] words)
        {
            throw new NotImplementedException();
        }

        private static void BuildTrie(TrieNode root, string[] words)
        {

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
                    if (index != word.Length - 1)
                    {
                        // check if the remaing word is a palindrome
                    }
                    else
                    {

                    }

                }
            }
        }

        private static int FindMatch(TrieNode trie, string word)
        {
            return -1;
        }

        private static void Insert (TrieNode root, string word)
        {

        }
       
    }
}