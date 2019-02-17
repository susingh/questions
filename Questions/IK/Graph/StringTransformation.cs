using System.Collections.Generic;
using System.Linq;

namespace Questions.IK.Graph
{
    class StringTransformation
    {
        /*
     * Complete the function below.
     */
        public static string[] string_transformation(string[] words, string start, string stop)
        {
            Dictionary<string, List<string>> graph = buildGraph(words, start, stop);

            Queue<string> q = new Queue<string>();
            Dictionary<string, string> parent = new Dictionary<string, string>();
            HashSet<string> seen = new HashSet<string>();

            q.Enqueue(start);
            seen.Add(start);
            parent[start] = null;
            bool oneTranformation = false;

            while (q.Count > 0)
            {
                var curr = q.Dequeue();

                if (curr == stop)
                {
                    if (oneTranformation)
                        return buildPath(parent, curr);
                    else
                        return new string[] { "-1" };
                
                }

                foreach (string node in graph[curr])
                {
                    if (!seen.Contains(node))
                    {
                        oneTranformation = true;
                        q.Enqueue(node);
                        seen.Add(node);
                        parent[node] = curr;
                    }
                }
            }

            return new string[] { "-1" };
        }

        private static string[] buildPath(Dictionary<string, string> parents, string word)
        {
            List<string> path = new List<string>();
            string curr = word;

            path.Add(curr);
            while (parents[curr] != null)
            {
                curr = parents[curr];
                path.Add(curr);
            }

            path.Reverse();
            return path.ToArray();
        }

        private static Dictionary<string, List<string>> buildGraph(string[] words, string start, string end)
        {
            //if (words.Length < start.Length * 26)
            //    return buildGraphLessWords(words, start, end);
            //else
            //    return buildGraphMoreWords(words, start, end);

            return buildGraphMoreWords(words, start, end);
        }

        private static Dictionary<string, List<string>> buildGraphLessWords(string[] words, string start, string end)
        {
            HashSet<string> set = new HashSet<string>();
            foreach (var word in words)
                set.Add(word);

            set.Add(start);
            set.Add(end);

            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

            for (int i = 0; i < set.Count; i++)
            {
                graph[set.ElementAt(i)] = new List<string>();

                for (int j = 0; j < set.Count; j++)
                {
                    if (i == j)
                        continue;

                    if (IsOneDistance(set.ElementAt(i), set.ElementAt(j)))
                    {
                        graph[set.ElementAt(i)].Add(set.ElementAt(j));
                    }
                }
            }

            return graph;
        }

        private static Dictionary<string, List<string>> buildGraphMoreWords(string[] words, string start, string end)
        {
            HashSet<string> set = new HashSet<string>();
            foreach (var word in words)
                set.Add(word);

            set.Add(start);
            set.Add(end);

            Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();

            foreach (var word in set)
            {
                char[] arr = word.ToCharArray();
                graph[word] = new List<string>();

                for (int i = 0; i < arr.Length; i++)
                {
                    char original = arr[i];
                    for (int j = 0; j < 26; j++)
                    {
                        int a = (int)'a';
                        char newCh = (char)(a + j);
                        if (newCh == original)
                            continue;

                        arr[i] = newCh;
                        string temp = new string(arr);

                        if (set.Contains(temp))
                        {
                            graph[word].Add(temp);
                        }
                    }

                    arr[i] = original;
                }
            }

            return graph;
        }

        private static bool IsOneDistance(string v1, string v2)
        {
            int distance = 0;

            for (int i = 0;  i < v1.Length; i++)
            {
                if (v1[i] != v2[i])
                {
                    distance++;
                }

                if (distance > 1)
                    return false;
            }

            return distance == 1;
        }
    }
}
