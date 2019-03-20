using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.DP_
{
    class CutRope
    {
        static long max_product_from_cut_pieces(int n)
        {
            /*
             * Write your code here.
             */
            if (n == 1)
            {
                return 1;
            }

            long val = 0;

            for (int i = 1; i < n; i++)
            {
                long res = max_product_from_cut_pieces(n - i);
                val = Math.Max(val, i* res);
                Console.WriteLine($"i:{i}, n:{n-1}, res:{res} val:{val}");
            }

            return val;
        }
    }
}