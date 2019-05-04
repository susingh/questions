using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.IK.Adhoc_
{
    class MoveZeros
    {
        public static void MoveZeroes(int[] nums)
        {
            int w = 0;
            int r = 0;

            while (r < nums.Length)
            {
                if (nums[r] == 0)
                {
                    r++;
                }
                else
                {
                    nums[w] = nums[r];
                    nums[r] = 0;
                    r++;
                    w++;
                }
            }
        }
    }
}
