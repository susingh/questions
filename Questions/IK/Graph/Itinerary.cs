using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Graph
{
    class Itinerary
    {
        public static IList<string> FindItinerary(List<List<string>> tickets)
        {
            var graph = BuildGraph(tickets);
            List<string> results = new List<string>();
            Stack<string> path = new Stack<string>();
            HashSet<string> seen = new HashSet<string>();
            DFS(graph, "JFK", tickets.Count, path, results, seen);
            return FindSmallestLexical(results);
        }

        private static List<string> FindSmallestLexical(List<string> result)
        {
            int i = 1;
            string minStr = result[0];
            while (i < result.Count)
            {
                if (string.Compare(minStr, result[i]) > 1)
                {
                    minStr = result[i];
                }
            }

            return minStr.Split(',').ToList();
        }

        private static void DFS(Dictionary<string, HashSet<string>> graph,
                         string airport,
                         int remainingFlights,
                         Stack<string> path,
                         List<string> results,
                         HashSet<string> seen)
        {
            path.Push(airport);
            Console.WriteLine(airport);

            if (remainingFlights == 0)
            {
                var list = path.ToList();
                list.Reverse();
                results.Add(string.Join(",", list));
                return;
            }

            for (int i = 0; i < graph[airport].Count; i++)
            {
                string connection = graph[airport].ElementAt(i);

                if (!seen.Contains($"{airport}{connection}"))
                {
                    seen.Add($"{airport}{connection}");
                    DFS(graph, connection, remainingFlights - 1, path, results, seen);
                    //seen.Remove($"{airport}{connection}");
                }

                //graph[airport].Remove(connection);
                //graph[airport].Add(connection);
            }

            path.Pop();
        }

        private static Dictionary<string, HashSet<string>> BuildGraph(List<List<string>> tickets)
        {
            var graph = new Dictionary<string, HashSet<string>>();

            foreach (var pair in tickets)
            {
                if (!graph.ContainsKey(pair[0]))
                {
                    graph[pair[0]] = new HashSet<string>();
                }

                if (!graph.ContainsKey(pair[1]))
                {
                    graph[pair[1]] = new HashSet<string>();
                }

                graph[pair[0]].Add(pair[1]);
            }

            return graph;
        }
    }
}