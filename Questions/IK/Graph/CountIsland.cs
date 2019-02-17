using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Graph
{
    class CountIsland
    {
        int countIslands(bool[,] graph)
        {
            int rows = graph.GetLength(0);
            int cols = graph.GetLength(1);

            bool[,] seen = new bool[rows, cols];
            int countIslands = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (!seen[i, j] && graph[i, j])
                    {
                        countIslands++;
                        explore(graph, i, j, seen);
                        //seen[i, j] = true;
                    }
                }
            }

            return countIslands;

        }
        void explore(bool[,] graph, int i, int j, bool[,] seen)
        {
            if (i == graph.GetLength(0) || j == graph.GetLength(1))
                return;

            if (!seen[i, j])
                return;

            seen[i, j] = true;
            explore(graph, i + 1, j, seen);
            explore(graph, i, j + 1, seen);
            explore(graph, i - 1, j, seen);
            explore(graph, i - 1, j - 1, seen);
        }
    }

}
