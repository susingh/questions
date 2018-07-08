using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.LeetCode
{
    public class ArrayIntersect
    {
        private Dictionary<int, List<int>> lookup = new Dictionary<int, List<int>>();

        public int[] Intersect(int[] nums1, int[] nums2)
        {
            List<int> returnValue = new List<int>();

            int count1 = nums1.Length;
            int count2 = nums2.Length;


            if (count1 < count2)
            {
                BuildLookup(nums2);
            }
            else
            {
                BuildLookup(nums1);
            }

            return returnValue.ToArray();
        }

        private void BuildLookup(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (!lookup.ContainsKey(nums[i]))
                {
                    lookup[nums[i]] = new List<int>();
                }

                if (i + 1 < nums.Length)
                {
                    lookup[nums[i]] = new List<int>();
                }


            }
        }

        public void Run()
        {
            Console.WriteLine(Intersect(new int[] { 1, 2, 3, 2, 1, 7 }, new int[] { 0, 3, 2, 0, 5 }));
        }
    }
}
