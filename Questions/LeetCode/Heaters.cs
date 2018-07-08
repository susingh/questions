using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questions.LeetCode
{
    public class Heaters
    {
        public int FindRadius(int[] houses, int[] heaters)
        {
            Array.Sort(heaters);
            long maxRadius = Int64.MinValue;
            
            for (int i = 0; i < houses.Length; i++)
            {
                long minRadius = Int64.MaxValue;

                for (int j = 0; j < heaters.Length; j++)
                {
                    long diff = Math.Abs(houses[i] - heaters[j]);

                    if (diff < minRadius)
                    {
                        minRadius = diff;
                    }
                }

                if (minRadius > maxRadius)
                {
                    maxRadius = minRadius;
                }
            }

            return (int)maxRadius;

            //HashSet<int> map = new HashSet<int>();
            //foreach (var item in heaters)
            //{
            //    map.Add(item);
            //}

            //int radius = 0;

            //for (int i = 0; i < houses.Length; i++)
            //{
            //    bool heaterFound = false;
            //    for (int j = radius * -1; j <= radius; j++)
            //    {
            //        if (map.Contains(houses[i]+j))
            //        {
            //            heaterFound = true;
            //            break;
            //        }
            //    }

            //    if (!heaterFound)
            //    {
            //        radius++;
            //        i = -1;
            //    }

            //}

            //return radius;
        }

        public void Run()
        {
            Console.WriteLine(FindRadius(new int[] { 1, 2, 3, 4 }, new int[] { 1, 4 }));
            Console.WriteLine(FindRadius(new int[] { 1, 2, 5, 6}, new int[] { 2, 5 }));
        }
    } 
}
