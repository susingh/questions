using System.Collections.Generic;

namespace Questions.IK.Graph
{
    class ZombieClusters
    {
        public static int zombieCluster(string[] zombies)
        {
            var graph = BuildGraph(zombies);
            HashSet<int> seen = new HashSet<int>();
            return zombieCluster(graph, seen);
        }

        private static int zombieCluster(IDictionary<int, HashSet<int>> graph, HashSet<int> seen)
        {
            int clusters = 0;
            for (int i = 0; i < graph.Keys.Count; i++)
            {
                if (!seen.Contains(i))
                {
                    clusters++;
                    explore(graph, seen, i);
                }
            }

            return clusters;
        }

        private static void explore(IDictionary<int, HashSet<int>> graph, HashSet<int> seen, int i)
        {
            Queue<int> q = new Queue<int>();
            seen.Add(i);
            q.Enqueue(i);

            while (q.Count > 0)
            {
                var node = q.Dequeue();

                foreach (var neighbor in graph[node])
                {
                    if (!seen.Contains(neighbor))
                    {
                        seen.Add(neighbor);
                        q.Enqueue(neighbor);
                    }
                }
            }
        }
        
        private static Dictionary<int, HashSet<int>> BuildGraph(string[] input)
        {
            Dictionary<int, HashSet<int>> adjList = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < input.Length; i++)
            {
                adjList[i] = new HashSet<int>();

                for (int j = 0; j < input[i].Length; j++)
                {
                    if (i != j && input[i][j] == '1')
                    {
                        adjList[i].Add(j);
                    }
                }
            }

            return adjList;
        }
    }
}
