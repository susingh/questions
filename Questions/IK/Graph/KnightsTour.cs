using System.Collections.Generic;

namespace Questions.IK.Graph
{
    class KnightsTour
    {
        public static int find_minimum_number_of_moves(int rows, int cols, int start_row, int start_col, int end_row, int end_col)
        {
            var graph = BuildGraphForKnight(rows, cols);
            return bfs(graph, start_row, start_col, end_row, end_col);
        }

        private static int bfs(IDictionary<Coordinate, HashSet<Coordinate>> graph, int start_row, int start_col, int end_row, int end_col)
        {
            HashSet<Coordinate> seen = new HashSet<Coordinate>();
            Queue<Coordinate> queue = new Queue<Coordinate>();
            var root = new Coordinate(start_row, start_col);
            var marker = new Coordinate(int.MaxValue, int.MaxValue);
            queue.Enqueue(root);
            queue.Enqueue(marker);

            seen.Add(root);
            int level = 0;

            while (queue.Count > 0)
            {
                var curr = queue.Dequeue();

                if (curr.c == int.MaxValue && curr.r == int.MaxValue)
                {
                    if (queue.Count > 0)
                    {
                        queue.Enqueue(marker);
                        level++;
                    }
                    continue;
                }

                if (curr.c == end_col && curr.r == end_row)
                {
                    return level;
                }

                foreach (var neighbor in graph[curr])
                {
                    if (seen.Contains(neighbor)) continue;
                    queue.Enqueue(neighbor);
                    seen.Add(neighbor);
                }

            }

            return -1;
        }

        private static IDictionary<Coordinate, HashSet<Coordinate>> BuildGraphForKnight(int rows, int cols)
        {
            IDictionary<Coordinate, HashSet<Coordinate>> graph = new Dictionary<Coordinate, HashSet<Coordinate>>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Coordinate curr = new Coordinate(i, j);
                    graph[curr] = new HashSet<Coordinate>();

                    AddToGraph(graph[curr], i - 2, j - 1, rows, cols);
                    AddToGraph(graph[curr], i - 2, j + 1, rows, cols);
                    AddToGraph(graph[curr], i + 2, j - 1, rows, cols);
                    AddToGraph(graph[curr], i + 2, j + 1, rows, cols);

                    AddToGraph(graph[curr], i - 1, j + 2, rows, cols);
                    AddToGraph(graph[curr], i + 1, j + 2, rows, cols);
                    AddToGraph(graph[curr], i - 1, j - 2, rows, cols);
                    AddToGraph(graph[curr], i + 1, j - 2, rows, cols);
                }
            }

            return graph;
        }

        private  static void AddToGraph(HashSet<Coordinate> list, int x, int y, int rows, int cols)
        {
            if (x >= 0 && x < rows && y >= 0 && y < cols)
            {
                list.Add(new Coordinate(x, y));
            }
        }

    }
}
