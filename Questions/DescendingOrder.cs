using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions
{
    public class DescendingOrder : IComparer<int>
    {
        public int Compare(int a, int b)
        {
            if (a == b)
            {
                return 0;
            }
            else if (a < b)
            {
                return 1;
            }
            else
                return -1;
        }
    }

}
