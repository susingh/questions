using System;
using System.Collections.Generic;

namespace Questions.IK.Graph
{
    class AlienDictionary
    {
        public static string find_order(string[] words)
        {
            if (words.Length == 1)
            {
                return words[0].Substring(0, 1);
            }

            Dictionary<char, List<char>> graph = BuildGraph(words);
            Dictionary<char, int> incomingEdges = BuildIncoming(graph);
            HashSet<char> seen = new HashSet<char>();
            List<char> order = new List<char>();

            // find the start with 0 incomingEdges
            Queue<char> q = new Queue<char>();
            foreach (var pair in incomingEdges)
            {
                if (pair.Value == 0)
                {
                    q.Enqueue(pair.Key);
                    seen.Add(pair.Key);
                }
            }

            while (q.Count != 0)
            {
                char curr = q.Dequeue();
                order.Add(curr);

                if (graph.ContainsKey(curr))
                {
                    foreach (var node in graph[curr])
                    {
                        if (!seen.Contains(node))
                        {
                            incomingEdges[node] = incomingEdges[node] - 1;
                            if (incomingEdges[node] == 0)
                            {
                                seen.Add(node);
                                q.Enqueue(node);
                            }
                        }

                    }
                }
            }

            return new string(order.ToArray());
        }

        private static Dictionary<char, List<char>> BuildGraph(string[] words)
        {
            Dictionary<char, List<char>> graph = new Dictionary<char, List<char>>();

            // compare each string with the next one
            // find mismatched characters
            // left char is smaller than right one

            for (int i = 0; i < words.Length - 1; i++)
            {
                int length = Math.Min(words[i].Length, words[i + 1].Length);

                for (int j = 0; j < length; j++)
                {
                    char a = words[i][j];
                    char b = words[i + 1][j];
                    if (a != b)
                    {
                        if (!graph.ContainsKey(a))
                        {
                            graph[a] = new List<char>();
                        }

                        graph[a].Add(b);
                        break;
                    }
                }
            }

            return graph;
        }

        private static Dictionary<char, int> BuildIncoming(Dictionary<char, List<char>> graph)
        {
            Dictionary<char, int> incoming = new Dictionary<char, int>();

            foreach (var pair in graph)
            {
                if (!incoming.ContainsKey(pair.Key))
                {
                    incoming[pair.Key] = 0;
                }

                foreach (char node in pair.Value)
                {
                    if (!incoming.ContainsKey(node))
                    {
                        incoming[node] = 0;
                    }

                    incoming[node] += 1;
                }
            }

            return incoming;
        }
    }
}
