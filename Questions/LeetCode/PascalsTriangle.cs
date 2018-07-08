using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.LeetCode
{
    public class PascalsTriangle : IQuestion
    {
        public IList<IList<int>> Generate(int numRows)
        {
            IList<IList<int>> rows = new List<IList<int>>();

            if (numRows == 0)
            {
                return rows;
            }

            for (int i = 0; i < numRows; i++)
            {
                int rowLength = i + 1;
                int[] row = new int[rowLength];

                int start = 0;
                int end = rowLength - 1;

                row[start] = 1;
                row[end] = 1;

                for (int j = start + 1; j < end; j++)
                {
                    int currentIndex = j;
                    if (i - i >= 0)
                    {
                        int rowSize = rows[i - 1].Count;

                        if (currentIndex - 1 >= 0)
                        {
                            row[currentIndex] += rows[i - 1].ElementAt(currentIndex - 1);
                        }

                        if (currentIndex < rowSize)
                        {
                            row[currentIndex] += rows[i - 1].ElementAt(currentIndex);
                        }
                    }
                }

                rows.Add(row);
            }

            return rows;
        }

        public void Run()
        {
            var result0 = Generate(0);
            var result3 = Generate(3);
            var result5 = Generate(5);
        }
    }
}
