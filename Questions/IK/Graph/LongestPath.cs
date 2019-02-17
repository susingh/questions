using System.Collections.Generic;

namespace Questions.IK.Graph
{
    class LongestPath
    {
        public static int[] find_longest_path(int dag_nodes, int[] dag_from, int[] dag_to, int[] dag_weight, int from_node, int to_node)
        {
            var graph = buildGraph(dag_nodes, dag_from, dag_to, dag_weight);
            HashSet<int> seen = new HashSet<int>();
            Dictionary<int, int> parents = new Dictionary<int, int>();

            long[] weights = new long[dag_nodes + 1];
            weights[0] = -1;

            Queue<int> q = new Queue<int>();
            q.Enqueue(from_node);
            seen.Add(from_node);
            parents[from_node] = -1;

            while (q.Count != 0)
            {
                int curr = q.Dequeue();

                foreach (var node in graph[curr])
                {
                    if (!seen.Contains(node.Vertex))
                    {
                        q.Enqueue(node.Vertex);
                        seen.Add(node.Vertex);
                    }

                    long newWeight = weights[curr] + node.Weight;

                    if (newWeight > weights[node.Vertex])
                    {
                        weights[node.Vertex] = newWeight;
                        parents[node.Vertex] = curr;
                    }
                }
            }

            return buildPath(parents, to_node);
        }

        private static int[] buildPath(Dictionary<int, int> parents, int to_node)
        {
            int curr = to_node;
            List<int> path = new List<int>();

            while (curr != -1)
            {
                path.Add(curr);
                curr = parents[curr];
            }

            path.Reverse();
            return path.ToArray();
        }

        private class Node
        {
            public int Vertex;
            public int Weight;
        }

        private static Dictionary<int, List<Node>> buildGraph(int dag_nodes, int[] dag_from, int[] dag_to, int[] dag_weight)
        {
            Dictionary<int, List<Node>> graph = new Dictionary<int, List<Node>>();

            for (int i = 0; i < dag_nodes; i++)
            {
                graph[i + 1] = new List<Node>();
            }

            if (dag_from.Length > 0)
            {
                for (int i = 0; i < dag_from.Length; i++)
                {
                    graph[dag_from[i]].Add(new Node() { Vertex = dag_to[i], Weight = dag_weight[i] });
                }
            }

            return graph;
        }
    }
}
