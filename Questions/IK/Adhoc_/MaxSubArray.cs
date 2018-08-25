using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Adhoc_
{
    class MaxSubArray
    {
        public int start;
        public int end;
        public int val;

        public MaxSubArray()
        {
            start = -1;
            end = -1;
            val = int.MinValue;
        }
    }

    class MaxSubArrayLong
    {
        public int start;
        public int end;
        public long val;

        public MaxSubArrayLong()
        {
            start = -1;
            end = -1;
            val = long.MinValue;
        }
    }

}
