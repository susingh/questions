using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Adhoc_
{
    class AdhocDriver : IQuestion
    {
        public void Run()
        {
            var sol
                = Sum_Zero.sumZero(new int[] { 5, 1, 2, -3, 7, -4 });
                //= Histogram.findMaxPossibleArea(new long[] { 1, 1, 1, 10, 1, 1, 1 }, 0, 6);
                // = MaxSubsetSum.MaxSumSubArray(new int[] { 5, -4, 4, -3, 11 });
        }
    }
}
