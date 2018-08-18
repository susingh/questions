using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Graph
{
    class KeysAndDoors
    {
        public static int[][] find_shortest_path(string[] grid)
        {
            Stack<Coordinate> path = new Stack<Coordinate>();
            List<Coordinate> shortestPath = new List<Coordinate>();
            find_shortest_path(grid, path, shortestPath);
            return GetShortestPath(shortestPath);
        }

        private static int[][] GetShortestPath(List<Coordinate> path)
        {
            return null;
        }

        private static void find_shortest_path(string[] grid, Stack<Coordinate> path, List<Coordinate> shortestPath)
        {
            bool[,] seen = new bool[grid.Length, grid[0].Length];
            FindStartEnd(grid, out Coordinate start, out Coordinate end);
            HashSet<char> keys = new HashSet<char>();

            Queue<Coordinate> q = new Queue<Coordinate>();
            q.Enqueue(start);
            seen[start.r, start.c] = true;

            while (q.Count > 0)
            {
                var curr = q.Dequeue();

                if (IsEnd(grid, curr))
                {
                    if (shortestPath.Count == 0 || (shortestPath.Count > 0 && path.Count < shortestPath.Count))
                    {
                        // we have a new shortest path
                        shortestPath.Clear();
                        var array = path.ToArray();
                        Array.Sort(array);
                        shortestPath.AddRange(array);

                        return;
                    }
                }
                else if (IsDoor(grid, curr) && !keys.Contains(grid[curr.r][curr.c]))
                {
                    path.Clear();
                    return;
                }

                if (IsKey(grid, curr))
                {
                    if (!keys.Contains(grid[curr.r][curr.c]))
                    {
                        keys.Add(grid[curr.r][curr.c]);
                        seen = new bool[grid.Length, grid[0].Length];
                    }
                }

                path.Push(curr);
                Walk(grid, seen, curr.r - 1, curr.c, q);
                Walk(grid, seen, curr.r + 1, curr.c, q);
                Walk(grid, seen, curr.r, curr.c - 1, q);
                Walk(grid, seen, curr.r, curr.c + 1, q);
                //path.Pop();
            }
        }

        private static void Walk(string[] grid, bool[,] seen, int r, int c, Queue<Coordinate> q)
        {
            if (r >=0 && r < grid.Length && c >= 0 && c < grid[0].Length && !seen[r, c])
            {
                q.Enqueue(new Coordinate(r, c));
                seen[r, c] = true;
            }
        }

        private static bool IsEnd(string[] grid, Coordinate node)
        {
            return grid[node.r][node.c] == '+';
        }

        private static bool IsKey(string[] grid, Coordinate node)
        {
            char ch = grid[node.r][node.c];
            return ch >= 'a' && ch <= 'z';
        }

        private static bool IsDoor(string[] grid, Coordinate node)
        {
            char ch = grid[node.r][node.c];
            return ch >= 'A' && ch <= 'Z';
        }


        private static void FindStartEnd(string[] grid, out Coordinate start, out Coordinate end)
        {
            start = null;
            end = null;

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == '@')
                    {
                        start = new Coordinate(i, j);
                    }
                    else if (grid[i][j] == '+')
                    {
                        end = new Coordinate(i, j);
                    }
                }
            }
        }
    }
}
