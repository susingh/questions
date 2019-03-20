using Questions.IK.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.String
{
    class BoggleSolver
    {
        public static string[] findWords(string[] dictionaryList, char[][] board)
        {
            // for each word
            // start searching each word on the board.
            // keep track of visited nodes
            Dictionary<char, List<Coordinate>> map = BuildFreqMap(board);
            HashSet<string> result = new HashSet<string>();
            HashSet<string> dictionary = new HashSet<string>(dictionaryList);

            foreach (var word in dictionary)
            {
                char firstCh = word[0];
                if (!map.ContainsKey(firstCh))
                    continue;

                // for each starting location of the word
                for (int i = 0; i < map[firstCh].Count; i++)
                {
                    HashSet<Coordinate> visited = new HashSet<Coordinate>();
                    DFS(board, word, 0, map[firstCh][i], visited, result);
                }
            }

            return result.ToArray();
        }

        static void DFS(char[][] board, string word, int i, Coordinate c, HashSet<Coordinate> visited, HashSet<string> result)
        {
            if (c.r == board.Length || c.c == board[0].Length || c.r < 0 || c.c < 0)
                return;

            if (i == word.Length)
                return;

            if (board[c.r][c.c] != word[i])
                return;

            visited.Add(c);

            if (i == word.Length - 1)
            {
                result.Add(word);
                return;
            }
          
            DFS(board, word, i + 1, new Coordinate(c.r, c.c + 1), visited, result);
            DFS(board, word, i + 1, new Coordinate(c.r, c.c - 1), visited, result);
            DFS(board, word, i + 1, new Coordinate(c.r + 1, c.c), visited, result);
            DFS(board, word, i + 1, new Coordinate(c.r - 1, c.c), visited, result);
        }

        static Dictionary<char, List<Coordinate>> BuildFreqMap(char[][] board)
        {
            Dictionary<char, List<Coordinate>> map = new Dictionary<char, List<Coordinate>>();
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board.Length; j++)
                {
                    char ch = board[i][j];
                    if (!map.ContainsKey(ch))
                    {
                        map[ch] = new List<Coordinate>();
                    }

                    map[ch].Add(new Coordinate(i, j));
                }
            }
            return map;
        }
    }
}
