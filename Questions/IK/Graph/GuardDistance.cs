using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Graph
{
    class GuardDistance
    {
        public static int[,] find_shortest_distance_from_a_guard(char[,] grid)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            int[,] distance = new int[rows, cols];

            for (int i= 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    distance[i, j] = DoBFS(grid, i, j);
                }
            }

            return distance;
        }
       
        private static int DoBFS (char[,] graph, int i, int j)
        {
            HashSet<Coordinate> seen = new HashSet<Coordinate>();
            Queue<Coordinate> q = new Queue<Coordinate>();
            Coordinate start = new Coordinate(i, j);
            Dictionary<Coordinate, Coordinate> parents = new Dictionary<Coordinate, Coordinate>();

            q.Enqueue(start);
            seen.Add(start);
            parents[start] = null;

            while (q.Count != 0)
            {
                var curr = q.Dequeue();

                if (IsGuard(graph, curr))
                {
                    return GetDistance(parents, curr);
                }

                if (IsWall(graph, curr))
                {
                    continue;
                }

                foreach (var item in GetNeighbors(graph, curr))
                {
                    if (!seen.Contains(item))
                    {
                        seen.Add(item);
                        q.Enqueue(item);
                        parents[item] = curr;
                    }
                }
            }

            return -1;
        }

        private static int GetDistance(Dictionary<Coordinate, Coordinate> parents, Coordinate x)
        {
            Coordinate curr = x;
            int distance = -1;
            while (curr != null)
            {
                distance++;
                curr = parents[curr];
            }
            return distance;
        }

        private static bool IsWall(char[,] grid, Coordinate curr)
        {
            return grid[curr.r, curr.c] == 'W';
        }

        private static bool IsGuard(char[,] grid, Coordinate curr)
        {
            return grid[curr.r, curr.c] == 'G';
        }


        private static List<Coordinate> GetNeighbors(char[,] grid, Coordinate x)
        {
            List<Coordinate> neighbors = new List<Coordinate>();

            if (x.r - 1 >= 0)
                neighbors.Add(new Coordinate(x.r - 1, x.c));

            if (x.r + 1 < grid.GetLength(0))
                neighbors.Add(new Coordinate(x.r + 1, x.c));

            if (x.c + 1 < grid.GetLength(1))
                neighbors.Add(new Coordinate(x.r, x.c + 1));

            if (x.c - 1 >= 0)
                neighbors.Add(new Coordinate(x.r, x.c - 1));

            return neighbors;
        }
    }
}