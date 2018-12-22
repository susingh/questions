using Questions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.DataStructures
{
    public class PrefixTree
    {
        private readonly TrieNode _root;

        public PrefixTree()
        {
            _root = new TrieNode();
        }

        public void Add(string word)
        {
            TrieNode curr = _root;

            for (int i = 0; i < word.Length; i++)
            {
                if (!curr.Children.ContainsKey(word[i]))
                {
                    curr.Children[word[i]] = new TrieNode();
                }

                curr = curr.Children[word[i]];
            }

            curr.isEOW = true;
        }

        public bool Find(string word)
        {
            TrieNode curr = _root;

            for (int i = 0; i < word.Length; i++)
            {
                if (!curr.Children.ContainsKey(word[i]))
                {
                    return false;
                }

                curr = curr.Children[word[i]];
            }

            return curr.isEOW;
        }

        public List<string> PrefixMatch (string word)
        {
            TrieNode curr = _root;
            Stack<char> path = new Stack<char>();
            List<string> matchingWords = new List<string>();

            for (int i = 0; i < word.Length; i++)
            {
                if (!curr.Children.ContainsKey(word[i]))
                {
                    return matchingWords;
                }

                path.Push(word[i]);
                curr = curr.Children[word[i]];
            }

            DFS(curr, path, matchingWords);
            return matchingWords;
        }

        private void DFS(TrieNode node, Stack<char> path, List<string> matchingWords)
        {
            if (node.isEOW)
            {
                matchingWords.Add(GetString(path));
            }

            foreach (var pair in node.Children)
            {
                path.Push(pair.Key);
                DFS(pair.Value, path, matchingWords);
                path.Pop();
            }
        }

        private string GetString(Stack<char> path)
        {
            return new string(path.Reverse().ToArray());
        }
    }
}
