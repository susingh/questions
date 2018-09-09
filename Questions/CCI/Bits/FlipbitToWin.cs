using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.CCI.Bits
{
    class FlipbitToWin
    {
        public static int Flip(int num)
        {
            //  11011101111
            bool bitFlippped = false;
            int start = 0;
            int end = start;
            int longestLength = 0;
            int lastOffBitIndex = 0;

            for (int i = 0; i < 32; i++)
            {
                bool curBit = BitDriver.Getbit(num, i);
                if (curBit)
                {
                    end++;
                }
                else
                {
                    if (!bitFlippped)
                    {
                        bitFlippped = true;
                        lastOffBitIndex = i;
                        end++;
                    }
                    else
                    {
                        int length = end - start;
                        if (length > longestLength)
                        {
                            longestLength = length;
                        }

                        i = lastOffBitIndex + 1;
                        start = i;
                        end = start;
                        bitFlippped = false;
                    }
                }

            }

            return longestLength;
        }
    }
}
