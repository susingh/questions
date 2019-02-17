using Questions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Graph
{
    class TopologicalSort
    {
        Dictionary<Vertex, int> buildInDegree(Dictionary<Vertex, List<Vertex>> graph)
        {
            Dictionary<Vertex, int> inDegree = new Dictionary<Vertex, int>();
            foreach (var pair in graph)
            {
                if (!inDegree.ContainsKey(pair.Key))
                {
                    inDegree[pair.Key] = 0;
                }

                foreach (var node in pair.Value)
                {
                    if (!inDegree.ContainsKey(node))
                    {
                        inDegree[node] = 0;
                    }

                    inDegree[node] = inDegree[node] + 1;
                }
            }

            return inDegree;
        }

        void takeCourses(Dictionary<Vertex, List<Vertex>> graph)
        {
            Dictionary<Vertex, int> inDegree = buildInDegree(graph);

            // find the starting nodes
            Queue<Vertex> q = new Queue<Vertex>();
            foreach (var node in inDegree)
            {
                if (node.Value == 0)
                {
                    q.Enqueue(node.Key);
                }
            }

            while (q.Count > 0)
            {
                var curr = q.Dequeue();

                Console.WriteLine(curr.label);

                foreach (var node in curr.Neighbors)
                {
                    inDegree[node] = inDegree[node] - 1;

                    if (inDegree[node] == 0)
                    {
                        q.Enqueue(node);
                    }
                }
            }
        }
    }
}
