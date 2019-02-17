using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Graph
{
    /// <summary>
    /// Space: O(row + col)) Time: 2 ^ O(row + col)
    /// </summary>
    class CountPaths
    {
        int CoinPaths(int[][] grid)
        {
            return CoinPaths(grid, 0, 0);
        }

        int CoinPaths(int[][] grid, int i, int j)
        {
            if (i == grid.Length) return 0;
            if (j == grid[0].Length) return 0;

            if (i == grid.Length - 1 && j == grid[0].Length - 1)
            {
                return 1;
            }

            int downPaths = CoinPaths(grid, i, j + 1);
            int rightPaths = CoinPaths(grid, i + 1, j);

            return downPaths + rightPaths;
        }
    }
}
