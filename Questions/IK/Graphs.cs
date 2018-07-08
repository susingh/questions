using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK
{
    class Coordinate 
    {
        public int r;
        public int c;
        public Coordinate (int r, int c)
        {
            this.c = c;
            this.r = r;
        }

        public override bool Equals(object obj)
        {
            var temp = obj as Coordinate;
            return (temp.c == c && temp.r == r);
        }
        public override int GetHashCode()
        {
            return r.GetHashCode() ^ c.GetHashCode();
        }
    }

    class Graphs : IQuestion
    {

        static int find_minimum_number_of_moves(int rows, int cols, int start_row, int start_col, int end_row, int end_col)
        {
            // Write your code here.
            var graph = BuildGraphForKnight(rows, cols);
            return bfs(graph, start_row, start_col, end_row, end_col);
        }

        static int bfs(IDictionary<Coordinate, HashSet<Coordinate>> graph, int start_row, int start_col, int end_row, int end_col)
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
                
                if(curr.c == int.MaxValue && curr.r == int.MaxValue)
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

        static IDictionary<Coordinate, HashSet<Coordinate>> BuildGraphForKnight(int rows, int cols)
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

                    AddToGraph(graph[curr], i - 1 , j + 2, rows, cols);
                    AddToGraph(graph[curr], i + 1, j + 2, rows, cols);
                    AddToGraph(graph[curr], i - 1, j - 2, rows, cols);
                    AddToGraph(graph[curr], i + 1, j - 2, rows, cols);
                }
            }

            return graph;
        }

        static void AddToGraph(HashSet<Coordinate> list, int x, int y, int rows, int cols)
        {
            if (x >=0 && x < rows && y >= 0 && y < cols)
            {
                list.Add(new Coordinate(x, y));
            }
        }

        public void Run()
        {
            //throw new NotImplementedException();
            var result = find_minimum_number_of_moves(2, 7, 0, 5, 1, 1);
        }
    }
}
