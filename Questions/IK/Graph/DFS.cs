using Questions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Graph
{
    class DFS
    {
        void dfs(List<Vertex> graph)
        {
            HashSet<int> seen = new HashSet<int>();
            foreach (var node in graph)
            {
                explore(node, seen);
                Console.WriteLine("---");
            }
        }

        void explore(Vertex node, HashSet<int> seen)
        {
            if (seen.Contains(node.label))
            {
                return;
            }

            Console.Write(node.label);
            seen.Add(node.label);
	
	        foreach (var neighbor in node.Neighbors)
            {
                explore(neighbor, seen);
            }
        }
    }
}
