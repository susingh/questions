using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.CCI.Bits
{
    class BitDriver : IQuestion
    {
        public static bool Getbit(int num, int i)
        {
            // 00100 -> 11011
            int mask = 1 << i;
            return (num & mask) != 0;
        }

        public static int Clearbit(int num, int i)
        {
            int mask = ~(1 << i);
            return num & mask;
        }

        public static int Setbit(int num, int i)
        {
            int mask = 1 << i;
            return num | mask;
        }

        public static int Updatebit(int num, int i, bool val)
        {
            bool currBit = Getbit(num, i);
            if (currBit != val)
            {
                num = Clearbit(num, i);

                if (val)
                {
                    num = Setbit(num, i);
                }
            }

            return num;
        }

        public void Run()
        {
            var sol
                 // = Insertion.insert(1024, 19, 2, 6);
                 // = FlipbitToWin.Flip(1775);
                 = PairwiseFlip.Flip(107);
        }
    }
}
