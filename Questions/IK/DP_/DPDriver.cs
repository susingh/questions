using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.DP_
{
    class DPDriver : IQuestion
    {
        /*
         * DP vs Recursion with Memoization. 
         * Depending on the number of possible sub problems, we can choose one vs the other.
         * A DP solves each and every sub problem. A memoization solution only solves the problems that actually occur.
         * So if the recursion is of the sort: +1, -1, then DP is more optimal.
         * However, if the recursion is of the sort: +d, -d, then memoization can be more optimal.
         */

        public void Run()
        {
            int[,] arr = new int[,]
            {
                { 1, 4, 5, 7, 10},
                { 20, 1, 3, 15, 12},
                { 13, 10, 11, 6, 8},
            };

            var sol
                // = MaxPath.Max_Path(arr);
                // = CoinChange.Coin_Change(8, new int[] { 2, 3, 5 });
                // = Robbery.maxStolenValue(new int[] { 8, 9, 9, 10, 5, 7, 3, 9, 2, 5 });
                // = Robbery.maxStolenValue(new int[] { 1, 6, 4, 5, 9});
                = KnightsTour.numPhoneNumbers(1, 2);


        }
    }
}
