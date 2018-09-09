using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.CCI.Bits
{
    class PairwiseFlip
    {
        // 01101011 -> 10010111

        public static int Flip(int num)
        {
            //return FlipMasking(num);
            return FlipPairwise(num);
        }

        private static int FlipPairwise(int num)
        {
            int a = num;
            int index = 0;

            while (a != 0)
            {
                bool x = (a & 1) == 1;
                bool y = (a & 2) == 2;

                if (x != y)
                {
                    num = BitDriver.Updatebit(num, index, y);
                    num = BitDriver.Updatebit(num, index + 1, x);
                }

                a = a >> 2;
                index += 2;
            }

            return num;
        }

        private static uint FlipMasking(uint num)
        {
            return (num & 0xaaaaaaaa) >> 1 | (num & 0x55555555) << 1;
        }
    }
}
