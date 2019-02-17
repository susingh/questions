using Questions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Graph
{
    class BFS
    {
        List<int> bfs(Vertex start, Vertex target)
        {
            HashSet<int> seen = new HashSet<int>();
            Dictionary<int, int> distance = new Dictionary<int, int>();
            Dictionary<int, Vertex> prev = new Dictionary<int, Vertex>();

            Queue<Vertex> q = new Queue<Vertex>();

            q.Enqueue(start);
            seen.Add(start.label);
            distance[start.label] = 0;
            prev[start.label] = null;

            while (q.Count > 0)
            {
                Vertex curr = q.Dequeue();

                if (curr == target)
                {
                    //return distance[target.label];
                    return buildPath(prev, target);
                }

                foreach (var node in curr.Neighbors)
                {
                    if (!seen.Contains(node.label))
                    {
                        q.Enqueue(node);
                        seen.Add(node.label);
                        distance[node.label] = distance[curr.label] + 1;
                        prev[node.label] = curr;
                    }
                }
            }

            return null;
        }

        List<int> buildPath(Dictionary<int, Vertex> prev, Vertex target)
        {
            List<int> path = new List<int>();
            Vertex curr = target;

            while (prev.ContainsKey(curr.label))
            {
                path.Add(curr.label);
                curr = prev[curr.label];
            }

            path.Add(curr.label);
            path.Reverse();
            return path;
        }

    }
}
