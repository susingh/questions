using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Graph
{
    public class DAGCycle
    {
        public static bool hasCycle(int N, int M, List<List<int>> edges)
        {
            // Write your code here
            Dictionary<int, List<int>> graph = BuildGraph(N, edges);
            HashSet<int> seen = new HashSet<int>();
            HashSet<int> ancestors = new HashSet<int>();

            bool val = false;
            foreach (var node in graph.Keys)
            {
                val |= HasCycle(graph, node, seen, ancestors);
            }

            return val;
        }

        private static Dictionary<int, List<int>> BuildGraph(int vertex, List<List<int>> edges)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
            for (int i = 0; i < vertex; i++)
            {
                graph[i] = new List<int>();
            }

            foreach (var edge in edges)
            {
                int from = edge[0];
                int to = edge[1];

                graph[from].Add(to);
            }

            return graph;
        }

        private static bool HasCycle(Dictionary<int, List<int>> graph, int vertex, HashSet<int> seen, HashSet<int> parents)
        {
            if (parents.Contains(vertex))
                return true;

            if (seen.Contains(vertex))
                return false;

            seen.Add(vertex);

            bool val = false;
            parents.Add(vertex);

            foreach (var neighbor in graph[vertex])
            {
                val |= HasCycle(graph, neighbor, seen, parents);
            }

            parents.Remove(vertex);

            return val;
        }
    }
}
