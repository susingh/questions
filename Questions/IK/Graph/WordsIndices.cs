using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Graph
{
    class WordsIndices
    {
        public static List<List<int>> find_words(string text, List<string> words)
        {
            //return find_words_using_hashmap(text, words);
            return find_words_using_trie(text, words);
        }

        private static List<List<int>> find_words_using_hashmap(string text, List<string> words)
        {
            var map = buildHashMap(text);
            List<List<int>> indices = new List<List<int>>();
            foreach (var item in words)
            {
                if (map.ContainsKey(item))
                {
                    indices.Add(map[item]);
                }
                else
                {
                    indices.Add(new List<int> { -1 });
                }
            }

            return indices;
        }

        private static Dictionary<string, List<int>>  buildHashMap(string text)
        {
            Dictionary<string, List<int>> map = new Dictionary<string, List<int>>();
            
            int i = 0;
            while (i < text.Length)
            {
                int j = i;

                while (j < text.Length && text[j] != ' ')
                    j++;

                // i -> j-1
                string word = text.Substring(i, j - 1 - i + 1);
                if (!map.ContainsKey(word))
                {
                    map[word] = new List<int>();
                }

                map[word].Add(i);
                i = j + 1;
            }

            return map;
        }

        private static List<List<int>> find_words_using_trie(string text, List<string> words)
        {
            var root = buildTrie(text);
            List<List<int>> indices = new List<List<int>>();
            foreach (var item in words)
            {
                indices.Add(FindWord(root, item));
            }

            return indices;
        }

        private static List<int> FindWord(TrieNodeCustom root, string word)
        {
            TrieNodeCustom curr = root;
            for (int i = 0; i < word.Length; i++)
            {
                if (!curr.Children.ContainsKey(word[i]))
                    return new List<int> { -1 };

                curr = curr.Children[word[i]];
            }

            if (curr.Indicies.Count == 0)
            {
                return new List<int> { -1 };
            }

            return curr.Indicies;
        }

        private class TrieNodeCustom
        {
            public Dictionary<char, TrieNodeCustom> Children;
            public List<int> Indicies;

            public TrieNodeCustom()
            {
                Children = new Dictionary<char, TrieNodeCustom>();
                Indicies = new List<int>();
            }
        }

        private static TrieNodeCustom buildTrie(string text)
        {
            TrieNodeCustom root = new TrieNodeCustom();

            int i = 0;
            while (i < text.Length)
            {
                int j = i;

                while (j < text.Length && text[j] != ' ')
                    j++;

                string word = text.Substring(i, j - 1 - i + 1);

                TrieInsert(root, word, i);

                i = j + 1;
            }

            return root; 
        }

        private static void TrieInsert(TrieNodeCustom root, string word, int start)
        {
            TrieNodeCustom curr = root;

            int i = 0;

            while (i < word.Length)
            {
                if (!curr.Children.ContainsKey(word[i]))
                {
                    curr.Children[word[i]] = new TrieNodeCustom();
                }

                curr = curr.Children[word[i]];
                i++;
            }

            curr.Indicies.Add(start);
        }
    }
}