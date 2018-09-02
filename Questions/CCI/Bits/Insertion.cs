using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.CCI.Bits
{
    class Insertion
    {
        public static int insert(int m, int n, int i, int j)
        {
            // clear m from i to j
            //for (int a = i; a <= j; a++)
            //{
            //    m = BitDriver.Clearbit(m, a);
            //}

            int allOnes = ~0;
            int leftMask = allOnes << (j + 1);

            int rightMask = (1 << i) - 1;
            int mask = leftMask | rightMask;

            // clear the bits
            m = m & mask;

            // left shift n by i
            n = n << i;

            // merge m and n
            return m | n;
        }
    }
}
