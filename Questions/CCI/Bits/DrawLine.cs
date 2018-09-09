using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.CCI.Bits
{
    class DrawLine
    {
        public static void Draw(Byte [] array, int width, int x1, int x2, int y)
        {
            // find full bytes
            // generate masks for start and end

            int start_offset = x1 % 8;
            int first_full_byte = x1 / 8;
            if (start_offset != 0)
            {
                first_full_byte++;
            }
            
            int end_full_byte = x2 / 8;
            int end_offset = x2 % 8;
            if (end_offset != 7)
            {
                end_full_byte--;
            }

            for (int i = first_full_byte; i <= end_full_byte; i++)
            {
                array[(width / 8) * y + i] = 0xFF;
            }

            if (x2 / 8 == x1 / 8)
            {

            }
            else
            {

            }

        }
    }
}
